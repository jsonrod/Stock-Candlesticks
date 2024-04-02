using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public partial class Form_StockViewer : Form
    {
        // List will contain all candlesticks read from the original CSV file loaded by user.
        List<CandleStick> candlesticks = null;
        // List will contain only the filtered candlesticks from the start and end date defined by user.
        BindingList<CandleStick> filteredCandleSticks = null;

        public Form_StockViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method serves as a second constructor to the Form class and accepts a string (path of file selected), starting
        /// date to assign to the DateTimePicker start object, ending date to assign to the DateTimePicker end object, and
        /// is used for any of the subsequently selected files after the first stock file.
        /// </summary>
        /// <param name="stockPath"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Form_StockViewer(string stockPath, DateTime startDate, DateTime endDate)
        {
            // Call the required method for Designer support
            InitializeComponent();
            // Assign the starting DateTimePicker object the value of the startDate argument
            dateTimePicker_StartDate.Value = startDate;
            // Assign the ending DateTimePicker object the value of the endDate argument
            dateTimePicker_EndDate.Value = endDate;
            // Reads the selected file and stores a reference to candlestick objects in the 'candleSticks' list of the derived form
            candlesticks = ReadFile(stockPath);
            // Filter candlesticks list from the specified date range selected in the child form
            FilterCandleSticks();
            // Adjust the range of Y-Values in the chart to portray all data more concisely
            NormalizeChart();
            // Display the list of filtered candlesticks to the chart object
            DisplayCandleSticks();
        }

        private void button_StockChooser_Click(object sender, EventArgs e)
        {
            // Invoking this method opens the File Explorer.
            openFileDialog_StockChooser.ShowDialog();
        }

        private void openFileDialog_StockChooser_FileOk(object sender, CancelEventArgs e)
        {
            // Store the selected value from the starting DateTimePicker object into a variable
            DateTime startDate = dateTimePicker_StartDate.Value;
            // Store the selected value from the ending DateTimePicker object into a variable
            DateTime endDate = dateTimePicker_EndDate.Value;
            // Store the the number of files selected from the file dialog chooser
            int nFiles = openFileDialog_StockChooser.FileNames.Count();
            // Iterate through each file selected
            for (int i = 0; i < nFiles; i++)
            {
                // Store the pathname of the currently indexed file
                string pathName = openFileDialog_StockChooser.FileNames[i];
                // Extract the canonical path from the path name and store only the file name itself
                string stock = Path.GetFileNameWithoutExtension(pathName);
                // Declare a temporary object of type Form_StockViewer
                Form_StockViewer form;
                // If the current file visited is the first file that was selected,
                if (i == 0)
                {
                    // Assign the properties of the main stock form to the temporary stock variable
                    form = this;
                    // Display the selected stock name on the upper-left hand corner and label it as parent since it is 
                    // will portray the form of the first stock selected
                    form.Text = $"Parent: {stock}";
                    // Reads the selected file and stores a reference to candlestick objects in the 'candleSticks' list
                    candlesticks = ReadFile(pathName);
                }
                // If the file selected was not the first one,
                else
                {
                    // Call the defined constructor that accepts a new path with the start and end dates of the primary form
                    form = new Form_StockViewer(pathName, startDate, endDate);
                    // Display the selected stock name on the upper-left hand corner and label it as child since it is
                    // will portray the form of the stocks selected after the first
                    form.Text = $"Child: {stock}";
                }
                // Explicitly call Show() to display the child forms (since they are not the main form from this program)
                form.Show();
                // Explicitly call BringToFront() to maintain the order of selected stocks to display the lastly selected file
                form.BringToFront();
            }
            // Filter candlesticks list from the specified date range selected in the main form
            FilterCandleSticks();
            // Adjust the range of Y-Values in the chart to portray all data more concisely
            NormalizeChart();
            // Display the list of filtered candlesticks to the chart object
            DisplayCandleSticks();
        }

        /// <summary>
        /// This function behaves as a utility method to the Form object. It accepts no parameters and does not return anything.
        /// </summary>
        private void ReadFile()
        {
            // Declare string variable to contain the file name chosen.
            string filename = openFileDialog_StockChooser.FileName;
            // File name is displayed on the upper-left corner of the windows form after selecting file.
            this.Text = filename;
            // list of candlesticks receives the returned list from the helper ReadFile function that accepted the file name as an argument.
            candlesticks = ReadFile(filename);
        }

        /// <summary>
        /// This function behaves as a helper method to the void ReadFile Form method. It accepts the filename as a string for the parameter and 
        /// returns a collection of candlesticks read from the CSV file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private List<CandleStick> ReadFile(string filename)
        {
            // Literal string containing the expected heading of the CSV file is declared for a comparison check prior to reading till end of file.
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";
            // Temporary list of candlesticks is instantiated to collect all instantiations of candlesticks.
            List<CandleStick> listOfCandleSticks = new List<CandleStick>(1500);
            // A stream reader object is instantiated within the 'using' brackets to discard its utilities once leaving the scope of function.
            // This object will read all contents of the CSV from beginning to EOF.
            using (StreamReader sr = new StreamReader(filename))
            {
                // Declare string variable to contain each line read one at a time in CSV file.
                string line = sr.ReadLine();
                // If the first line read matches the reference string, the contents of the file is correct and we can continue reading rest of file.
                if (line == referenceString)
                {
                    // Continues reading the CSV file until the end.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // This line instantiates a candlestick object per line of data read from the CSV file.
                        CandleStick cs = new SmartCandlestick(line);
                        listOfCandleSticks.Add(cs);
                    }
                }
                // If the first line read did not match the reference string, the contents of the file is not correct.
                else
                {
                    // The upper-left corner of the windows form will now portray a 'bad file' message alongside the filename chosen.
                    this.Text = $"Bad File: {filename}";
                }
            }
            // Returns the temporary instantiation of the list containing all candlesticks read from the file.
            return listOfCandleSticks;
        }

        /// <summary>
        /// This function behaves as a utility method to the Form object. It accepts no parameters and does not return anything.  
        /// </summary>
        private void FilterCandleSticks()
        {
            // Temporary list of candlesticks is assigned an instantiated filtered list returned from the second FilterCandleSticks method.
            List<CandleStick> boundCandleSticks = FilterCandleSticks(candlesticks, dateTimePicker_StartDate.Value, dateTimePicker_EndDate.Value);
            // The dynamic binding list will accept the returned list (now filtered) as the argument to the constructor for the IBindingList interface.
            filteredCandleSticks = new BindingList<CandleStick>(boundCandleSticks);
        }

        /// <summary>
        /// This function behaves as a helper method to the void FilterCandleSticks Form method. It accepts a list of candlesticks, start date, and end
        /// date to filter the original list into a smaller/bigger list specified by the date selection of the user.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<CandleStick> FilterCandleSticks(List<CandleStick> list, DateTime startDate, DateTime endDate)
        {
            comboBox_patterns.Items.Clear();
            // Temporary list of candlesticks is instantiated to contain new candlesticks within specified date range.
            List<CandleStick> boundCandleSticks = new List<CandleStick>(1500);
            // Loops through the provided list from the parameter to search for the filtering conditions.
            foreach (CandleStick cs in list)
            {
                // If the date on candlestick encountered is past the end date specified by the user, loop will exit and not add any more candlesticks.
                if (cs.date > endDate) break;
                // If the date is either the selected start date or higher,
                if (cs.date >= startDate)
                {
                    // Add desired candlestick object to the filtered list of candlesticks that will be used for display
                    boundCandleSticks.Add(cs);
                    // Add patterns that applies to the candlestick object to the ComboBox object
                    FillComboBoxPattern((SmartCandlestick)cs);
                }

            }
            // Filtered list of candlesticks is returned from the function.
            return boundCandleSticks;
        }

        /// <summary>
        /// This function behaves as a helper method to the Form class by dynamically adding all single-candlestick
        /// patterns detected by the selected range of candlesticks from the form.
        /// </summary>
        /// <param name="cs"></param>
        private void FillComboBoxPattern(SmartCandlestick cs)
        {
            // Iterate through all patterns in the dictionary property of the SmartCandlestick
            foreach (var kvp in cs.patterns)
            {
                // If the pattern is applicable (true) and it has yet to be inserted to the ComboBox list of items,
                if (kvp.Value && !comboBox_patterns.Items.Contains(kvp.Key))
                {
                    // Insert pattern selection to the list of items in ComboBox
                    comboBox_patterns.Items.Add(kvp.Key);
                }
            }
        }

        /// <summary>
        /// This function behaves as a utility method to the Form class. Within this method, the chart display the current list of 
        /// filtered candlesticks specified by the user.
        /// </summary>
        private void DisplayCandleSticks()
        {
            // Similar to the instruction above, the chart data source property is initialized to the filtered collection of candlesticks
            // to then visually plot each candlestick object to the chart.
            chart_CandleSticks.DataSource = filteredCandleSticks;
            // This triggers, invoking this method, the control of the chart to bind to its data source (filtered collection of candlesticks) and updates
            // the display based on current filtered list.
            chart_CandleSticks.DataBind();
        }
        
        /// <summary>
        /// This function behaves as another utility method to the Form class. In the scope of this method, the chart's Y-Axis range is filtered
        /// to adjust closer to the maximum and minimum Y value (open and close) and display a more clear view of the stock trend.
        /// </summary>
        private void NormalizeChart()
        {
            // Whenever there are no candlesticks within the filtered collection of candlesticks specified by the user,
            if (filteredCandleSticks.Count == 0)
            {
                // Display error message and prompt user to select a different date range.
                MessageBox.Show("There are currently no candlesticks to display.\nCheck date range.");
                // Exit from function since there is no available range to calculate.
                return;
            }
            // The minimum Y value displayed on the chart is set to the floor of 2% less than the smallest 'low' candlestick price. 
            chart_CandleSticks.ChartAreas["ChartArea_OHLC"].AxisY.Minimum = Math.Floor(filteredCandleSticks.Min(cs => (double)cs.low) * 0.98);
            // The maximum Y value displayed on the chart is set to the ceiling of 2% greater than the largest 'high' candlestick price.
            chart_CandleSticks.ChartAreas["ChartArea_OHLC"].AxisY.Maximum = Math.Ceiling(filteredCandleSticks.Max(cs => (double)cs.high) * 1.02);
        }

        /// <summary>
        /// This function behaves as a utility method to the Form class, specifically handling the event on the update button. It will re-display the
        /// new visual collection of candlesticks after user selects a different date range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            // Clear all annotated candlesticks present on the chart.
            chart_CandleSticks.Annotations.Clear();
            // Re-filter the list of candlesticks under new date range conditions.
            FilterCandleSticks();
            // Re-filter the range of Y values to correspond to the new collection of candlesticks.
            NormalizeChart();
            // Re-display the new filtered list of candlesticks to the data grid view and chart.
            DisplayCandleSticks();
        }

        private void comboBox_patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear all annotated candlesticks present on the chart to provide a blank canvas for the newly selected pattern.
            chart_CandleSticks.Annotations.Clear();
            // Iterate through all of the filtered candlesticks which are present on the chart
            for (int i = 0; i < filteredCandleSticks.Count; i++)
            {
                // Create a temporary SmartCandlestick object and assign it the casted CandleStick object in filtered list
                SmartCandlestick cs = (SmartCandlestick)filteredCandleSticks[i];
                // If the selected pattern in the ComboBox is applicable (present) to the current candlestick object,
                if (cs.patterns[comboBox_patterns.SelectedItem.ToString()])
                {
                    // Create a new arrow annotation to pointer to candlestick
                    ArrowAnnotation AA = new ArrowAnnotation();
                    // Set the color to match the color of the candlestick (whether it is bullish or bearish)
                    AA.BackColor = (cs.patterns["Bullish"]) ? Color.Lime : Color.Red;
                    // Set the height of the arrow to -2 to make the arrow annotation appear as a triangular arrow
                    AA.Height = -2;
                    // Set the width of the arrow to 0 to make it vertically point downward above the candlestick object
                    AA.Width = 0;
                    // Insert the arrow annotation object to the list of annotations on the chart object
                    chart_CandleSticks.Annotations.Add(AA);
                    // Set the position of the arrow annotation object to point to the specific candlestick object visitied currently
                    AA.SetAnchor(chart_CandleSticks.Series["Series_OHLC"].Points[i]);
                }
            }
            // Re-display the new set of annotations to respond to the selected pattern event handler
            chart_CandleSticks.Update();
        }
    }
}