using Chat_Room.Domain.Stocks;
using CsvHelper;
using RestSharp;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Chat_Room.Infraestructure.Stocks
{
    /// <summary>
    /// Class for that parses csv stocks from https://stooq.com.
    /// </summary>
    public class CsvStockSelect : IStockSelect
    {
        private const string HARDCODED_BASE_URL = "https://stooq.com/q/l";
        private const string PARAM_F = "sd2t2ohlcv";
        private const string PARAM_H = "";
        private const string PARAM_E = "csv";

        public async Task<StockData> GetStock(string stockCode)
        {
            try
            {
                RestClient client = new RestClient(HARDCODED_BASE_URL);
                RestRequest request = CreateRestRequest(stockCode);
                var responseStream = await client.DownloadStreamAsync(request);
                return ParseResponseStream(responseStream);
            }
            catch (Exception ex)
            {
                return StockData.ERROR_STOCK;
            }
        }

        private StockData ParseResponseStream(Stream responseStream)
        {
            using (var reader = new StreamReader(responseStream))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<StockData>().FirstOrDefault();
                }
            }
        }

        private RestRequest CreateRestRequest(string stockCode)
        {
            RestRequest request = new RestRequest();
            request.AddParameter("f", PARAM_F);
            request.AddParameter("h", PARAM_H);
            request.AddParameter("e", PARAM_E);
            request.AddParameter("s", stockCode);
            return request;
        }
    }
}
