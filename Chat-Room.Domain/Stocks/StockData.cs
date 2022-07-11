using System;

namespace Chat_Room.Domain.Stocks
{
    /// <summary>
    /// Model class for stock data.
    /// </summary>
    public class StockData
    {
        /// <summary>
        /// Error stock object.
        /// </summary>
        public readonly static StockData ERROR_STOCK = new StockData
        {
            Symbol = "ERROR"
        };


        /// <summary>
        /// The symbol of the stock.
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// String date of the stock.
        /// </summary>
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// String time of the stock.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Open value.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// High value.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Low value.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// Current volume.
        /// </summary>
        public long Volume { get; set; }
    }
}
