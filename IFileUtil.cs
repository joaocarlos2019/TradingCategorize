using TradingCategorize.Domain;

namespace TradingCategorize
{
    public interface IFileUtil
    {
        public List<string> ReadLinesForFile();

        public List<Trade> ReadParametersForFileAndCreateTrades(List<string> FileTrades);
    }
}
