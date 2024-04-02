namespace Project2
{
    partial class Form_StockViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_StockChooser = new System.Windows.Forms.Button();
            this.openFileDialog_StockChooser = new System.Windows.Forms.OpenFileDialog();
            this.button_Update = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label_StartDate = new System.Windows.Forms.Label();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label_EndDate = new System.Windows.Forms.Label();
            this.chart_CandleSticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox_patterns = new System.Windows.Forms.ComboBox();
            this.label_comboBoxPatterns = new System.Windows.Forms.Label();
            this.candleStickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_CandleSticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_StockChooser
            // 
            this.button_StockChooser.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.button_StockChooser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_StockChooser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_StockChooser.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StockChooser.Location = new System.Drawing.Point(43, 39);
            this.button_StockChooser.Name = "button_StockChooser";
            this.button_StockChooser.Size = new System.Drawing.Size(239, 49);
            this.button_StockChooser.TabIndex = 0;
            this.button_StockChooser.Text = "Choose a Stock";
            this.button_StockChooser.UseVisualStyleBackColor = false;
            this.button_StockChooser.Click += new System.EventHandler(this.button_StockChooser_Click);
            // 
            // openFileDialog_StockChooser
            // 
            this.openFileDialog_StockChooser.Filter = "Stock files|*.csv|Daily|*-Day.csv|Weekly|*-Week.csv|Monthly|*-Month.csv|AAPL|AAPL" +
    "-*|GOOG|GOOG-*|IBM|IBM-*|MSFT|MSFT-*";
            this.openFileDialog_StockChooser.Multiselect = true;
            this.openFileDialog_StockChooser.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_StockChooser_FileOk);
            // 
            // button_Update
            // 
            this.button_Update.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.button_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Update.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Location = new System.Drawing.Point(43, 122);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(239, 49);
            this.button_Update.TabIndex = 1;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = false;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(552, 39);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(332, 26);
            this.dateTimePicker_StartDate.TabIndex = 2;
            this.dateTimePicker_StartDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // label_StartDate
            // 
            this.label_StartDate.AutoSize = true;
            this.label_StartDate.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StartDate.Location = new System.Drawing.Point(406, 39);
            this.label_StartDate.Name = "label_StartDate";
            this.label_StartDate.Size = new System.Drawing.Size(140, 23);
            this.label_StartDate.TabIndex = 3;
            this.label_StartDate.Text = "Start Date";
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(552, 90);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(332, 26);
            this.dateTimePicker_EndDate.TabIndex = 4;
            this.dateTimePicker_EndDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label_EndDate
            // 
            this.label_EndDate.AutoSize = true;
            this.label_EndDate.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EndDate.Location = new System.Drawing.Point(432, 90);
            this.label_EndDate.Name = "label_EndDate";
            this.label_EndDate.Size = new System.Drawing.Size(114, 23);
            this.label_EndDate.TabIndex = 5;
            this.label_EndDate.Text = "End Date";
            // 
            // chart_CandleSticks
            // 
            this.chart_CandleSticks.BackColor = System.Drawing.Color.Ivory;
            chartArea1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            chartArea2.Name = "ChartArea_Volume";
            this.chart_CandleSticks.ChartAreas.Add(chartArea1);
            this.chart_CandleSticks.ChartAreas.Add(chartArea2);
            this.chart_CandleSticks.DataSource = this.candleStickBindingSource;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart_CandleSticks.Legends.Add(legend1);
            this.chart_CandleSticks.Location = new System.Drawing.Point(43, 241);
            this.chart_CandleSticks.Name = "chart_CandleSticks";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volume";
            this.chart_CandleSticks.Series.Add(series1);
            this.chart_CandleSticks.Series.Add(series2);
            this.chart_CandleSticks.Size = new System.Drawing.Size(847, 525);
            this.chart_CandleSticks.TabIndex = 7;
            this.chart_CandleSticks.Text = "chart1";
            // 
            // comboBox_patterns
            // 
            this.comboBox_patterns.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_patterns.FormattingEnabled = true;
            this.comboBox_patterns.Location = new System.Drawing.Point(552, 145);
            this.comboBox_patterns.Name = "comboBox_patterns";
            this.comboBox_patterns.Size = new System.Drawing.Size(186, 26);
            this.comboBox_patterns.TabIndex = 8;
            this.comboBox_patterns.Text = "Select a Pattern";
            this.comboBox_patterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_patterns_SelectedIndexChanged);
            // 
            // label_comboBoxPatterns
            // 
            this.label_comboBoxPatterns.AutoSize = true;
            this.label_comboBoxPatterns.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comboBoxPatterns.Location = new System.Drawing.Point(432, 145);
            this.label_comboBoxPatterns.Name = "label_comboBoxPatterns";
            this.label_comboBoxPatterns.Size = new System.Drawing.Size(114, 23);
            this.label_comboBoxPatterns.TabIndex = 9;
            this.label_comboBoxPatterns.Text = "Patterns";
            // 
            // candleStickBindingSource
            // 
            this.candleStickBindingSource.DataSource = typeof(Project2.CandleStick);
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1011, 882);
            this.Controls.Add(this.label_comboBoxPatterns);
            this.Controls.Add(this.comboBox_patterns);
            this.Controls.Add(this.chart_CandleSticks);
            this.Controls.Add(this.label_EndDate);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.label_StartDate);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_StockChooser);
            this.Name = "Form_StockViewer";
            this.Text = "Form_StockViewer";
            ((System.ComponentModel.ISupportInitialize)(this.chart_CandleSticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_StockChooser;
        private System.Windows.Forms.OpenFileDialog openFileDialog_StockChooser;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.Label label_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.Label label_EndDate;
        private System.Windows.Forms.BindingSource candleStickBindingSource;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_CandleSticks;
        private System.Windows.Forms.ComboBox comboBox_patterns;
        private System.Windows.Forms.Label label_comboBoxPatterns;
    }
}

