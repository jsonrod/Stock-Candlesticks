using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    /// <summary>
    /// This class expands the definition of a CandleStick object beyond the standard date, open, high, low, close, and volume
    /// properties. The SmartCandlestick class will now define additional properties such as a range, top price, bottom price, body
    /// range, upper tail, and lower tail describe more of the structure numerically and assist with other operations such as
    /// pattern detection (for the patterns property). This class will inherit from the subclass CandleStick.
    /// </summary>
    public class SmartCandlestick : CandleStick
    {
        // Range property
        public decimal range {  get; set; }
        // Top price property
        public decimal topPrice { get; set; }
        // Bottom price property
        public decimal bottomPrice {  get; set; }
        // Body range property
        public decimal bodyRange { get; set; }
        // Upper tail property
        public decimal upperTail {  get; set; }
        // Lower tail property
        public decimal lowerTail { get; set; }
        // Set of all patterns property
        public Dictionary<string, bool> patterns {  get; set; }

        /// <summary>
        /// This function behaves as an internal method used by the SmartCandlestick class at construction time to compute
        /// all non-pattern properties from the already derived properties (open, high, low, close)
        /// </summary>
        private void ComputeExtraProperties()
        {
            // Range contains the difference between the highest and lower prices during its duration
            range = high - low;
            // Top price contains the open price (if it is bearish) or the close price (if it is bullish)
            topPrice = Math.Max(open, close);
            // Top price contains the open price (if it is bullish) or the close price (if it is bearish)
            bottomPrice = Math.Min(open, close);
            // Body range contains the absolute difference between the opening and closing prices during its duration
            bodyRange = topPrice - bottomPrice;
            // Upper tail contains the difference between the highest price and top price
            upperTail = high - topPrice;
            // Lower tail contains the difference between the bottom price and lowest price
            lowerTail = bottomPrice - low;
        }

        /// <summary>
        /// This function behaves as an internal method used by the SmartCandlestick class at construction time to compute
        /// all pattern properties from the newly-defined non-pattern member variables which were computed from the already
        /// derived properties (open, high, low, close)
        /// </summary>
        private void ComputePatternProperties()
        {
            // Candlestick is bullish if the closing price is greater than the opening price
            patterns.Add("Bullish", close > open);
            // Candlestick is bearish if the closing price is less than the opening price
            patterns.Add("Bearish", close < open);
            // Candlestick is marubozu if the body range makes up anywhere from 96% to 100% of the overall range
            patterns.Add("Marubozu", bodyRange >= (decimal)(0.96) * range);
            // Candlestick is neutral if the opening and closing prices are equal
            patterns.Add("Neutral", topPrice == bottomPrice);
            // Candlestick is a hammer if the body range between 20% to 35% and allows the upper tail with only 0% to 4% of range
            patterns.Add("Hammer", bodyRange <= (decimal)(0.35) * range && bodyRange >= (decimal)(0.20) * range && (lowerTail <= (decimal)(0.65) * range && upperTail <= 5));
            // Candlestick is a doji if the body range is between 5% and 15% and the upper and lower tail ranges make up at least 25% of the range each
            patterns.Add("Doji", (bodyRange <= (decimal)(0.15) * range && bodyRange >= (decimal)(0.05)) && (upperTail >= (decimal)(25) && lowerTail >= (decimal)(25)));
            // Candlestick is a dragonfly doji of the body range is between 5% and 15% and the lower tail is at least 75% of the range
            patterns.Add("Dragonfly Doji", (bodyRange <= (decimal)(0.15) * range && bodyRange >= (decimal)(0.05)) && (lowerTail >= (decimal)(0.75) * range));
            // Candlestick is a dragonfly doji of the body range is between 5% and 15% and the upper tail is at least 75% of the range
            patterns.Add("Gravestone Doji", (bodyRange <= (decimal)(0.15) * range && bodyRange >= (decimal)(0.05)) && (upperTail >= (decimal)(0.75) * range));
        }

        /// <summary>
        /// This constructor accepts a single string line from a CSV file and invokes the constructor of the CandleStick class. It then
        /// computes all of the additional properties defined within the scope of SmartCandlestick.
        /// </summary>
        /// <param name="rowOfData"></param>
        public SmartCandlestick(string rowOfData) : base(rowOfData) 
        {
            // Instantiate the Dictionary pattern object
            patterns = new Dictionary<string, bool>();
            // Compute all of the non-pattern properties (top price, bottom price, range, body range, upper tail, lower tail)
            ComputeExtraProperties();
            // Compute all of the pattern properties (bullish, bearish, marubozu, neutral, hammer, doji, dragonfly doji, gravestone doji)
            ComputePatternProperties();
        }

    }
}
