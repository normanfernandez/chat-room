using Chat_Room.Domain.Stocks;
using Chat_Room.Infraestructure.Stocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chat_Room.Test.Stocks
{
    [TestClass]
    public class CsvStockSelectTest
    {
        
        [TestMethod]
        public void GetTest()
        {
            string stockCode = "aapl.us";
            IStockSelect stockSelect = new CsvStockSelect();
            var stock = stockSelect.GetStock(stockCode).Result;

            Assert.AreEqual("AAPL.US", stock.Symbol);
        }
    }
}
