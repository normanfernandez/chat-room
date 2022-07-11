using System.Threading.Tasks;

namespace Chat_Room.Domain.Stocks
{
    /// <summary>
    /// Interface for getting stock data.
    /// </summary>
    public interface IStockSelect
    {
        /// <summary>
        /// Get stock data by stock code.
        /// </summary>
        /// <param name="stockCode">The stock code to use in the search.</param>
        /// <returns></returns>
        Task<StockData> GetStock(string stockCode);
    }
}
