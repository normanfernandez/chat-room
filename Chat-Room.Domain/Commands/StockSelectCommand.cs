namespace Chat_Room.Domain.Commands
{
    public class StockSelectCommand : Command
    {
        public const string STOCK_COMMAND = "stock";

        public StockSelectCommand(string stockCode) : base(STOCK_COMMAND, stockCode)
        {
        }
    }
}
