using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    /// <summary>
    /// This class defines the basic properties within a candlestick object such as the open, high, low, close, volume, and date values. 
    /// It also contains a constructor that will instantiate a candlestick from a string of data read from a CSV file.
    /// </summary>
    public class CandleStick
    {
        // Open price propery
        public decimal open { get; set; }
        // High price property
        public decimal high { get; set; }
        // Low price property
        public decimal low { get; set; }
        // Close price property
        public decimal close { get; set; }
        // Volume (width) property
        public ulong volume { get; set; }
        // Date property
        public DateTime date { get; set; }

        /// <summary>
        /// This constructor explicitly defines the default constructor and sets all properties to 0.
        /// </summary>
        public CandleStick() { }

        /// <summary>
        /// This constructor accepts a single string line which will then parse each piece of data separated by commas, spaces, or quotation marks.
        /// to then instantiate the candlestick object.
        /// </summary>
        /// <param name="rowOfData"></param>
        public CandleStick(string rowOfData)
        {
            
            // Defines an array of characters that will be used as separators when splitting the input string rowOfData into substrings.
            char[] separators = new char[] { ',', ' ', '"' };
            
            // Defines an array of strings containing each sub string split from the separators.
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Temporary string variable is initialized to first element of subs array since that is the first value member read from the CSV.
            string dateString = subs[0];
            // Date string variable is parsed into a DateTime data type and assigned to the 'date' property of the candlestick object.
            date = DateTime.Parse(dateString);
            
            // Temporary decimal variable is declared to assist with parsing the open, high, low, and close properties.
            decimal temp;
            // Since TryParse returns a boolean value, success is initialized to verify that subs[1] (open data from CSV) was parsed correctly.
            bool success = decimal.TryParse(subs[1], out temp);
            // If the string was parsed into a decimal data type successfully, it will be assigned to the open property of the candlestick object.
            if (success) open = temp;

            // Since TryParse returns a boolean value, success is initialized to verify that subs[2] (high data from CSV) was parsed correctly.
            success = decimal.TryParse(subs[2], out temp);
            // If the string was parsed into a decimal data type successfully, it will be assigned to the high property of the candlestick object.
            if (success) high = temp;

            // Since TryParse returns a boolean value, success is initialized to verify that subs[3] (low data from CSV) was parsed correctly
            success = decimal.TryParse(subs[3], out temp);
            // If the string was parsed into a decimal data type successfully, it will be assigned to the low property of the candlestick object.
            if (success) low = temp;

            // Since TryParse returns a boolean value, success is initialized to verify that subs[4] (close data from CSV) was parsed correctly.
            success = decimal.TryParse(subs[4], out temp);
            // If the string was parsed into a decimal data type successfully, it will be assigned to the close property of the candlestick object
            if (success) close = temp;

            // Temporary ulong variable is declared to assist in parsing the volume property.
            ulong tempVolume;
            // Since TryParse returns a boolean value, success is initialized to verify that subs[6] (volume data from CSV) was parsed correctly.
            // We skipped subs[5] because that contained Adjusted Close data from CSV.
            success = ulong.TryParse(subs[6], out tempVolume);
            // If the string was parsed into an unsigned long data type successfully, it will be assigned to the volume property of the candlestick object.
            if (success) volume = tempVolume;

        }

    }
}
