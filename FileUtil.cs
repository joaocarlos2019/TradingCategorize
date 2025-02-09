using System.Diagnostics;
using System.Globalization;
using TradingCategorize.Domain;
using TradingCategorize.Domain.Abstract;
using TradingCategorize.Domain.Interfaces;

namespace TradingCategorize
{
    public class FileUtil:IFileUtil
    {       
        public List<string> ReadLinesForFile()
        {
            var fileRead = File.ReadLines("File\\FileProcessing.txt").ToList();
            return fileRead;
        }

        public List<Trade> ReadParametersForFileAndCreateTrades(List<string> FileTrades)
        {
            //Trata data de Referência e inicializa lista do Trade
            var referenceDate = DateTime.ParseExact(FileTrades[0].Trim(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            List<Trade> trades = new List<Trade>();

            //Lê as linhas de trade e cria os trades
            for (int numberline = 2; numberline < FileTrades.Count(); numberline++)
            {
                // Lê a operação
                var line = FileTrades[numberline].Trim().Split(' ');
                var value = double.Parse(line[0]);
                var clientSector = line[1];
                var nextPaymentDate = DateTime.ParseExact(line[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                // Cria o Trade    
                trades.Add(new Trade(value, clientSector, nextPaymentDate, referenceDate));
            }

            return trades;

        }

       

       


       
    }
}
