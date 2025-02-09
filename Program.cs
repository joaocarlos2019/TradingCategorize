// See https://aka.ms/new-conso.le-template for more information
using System.Globalization;
using TradingCategorize;
using TradingCategorize.Domain;
using TradingCategorize.Domain.Abstract;
using TradingCategorize.Domain.Interfaces;

IFileUtil _fileUtil = new FileUtil();
var lisvaluesofFile = _fileUtil.ReadLinesForFile();
List<Trade> trades = _fileUtil.ReadParametersForFileAndCreateTrades(lisvaluesofFile);

//Implementação das categorias de Trade baseadas no pattern ChainOfResponsibility
var expiredHandler = new ExpiredCategoryHandler();
var highRiskHandler = new HighRiskCategoryHandler();
var mediumRiskHandler = new MediumRiskCategoryHandler();

//Parametrização da ordem das Chains
expiredHandler.SetNext(highRiskHandler);
highRiskHandler.SetNext(mediumRiskHandler);

//Passa o trade e a data de Referência para realizar a classificação do trade.
foreach (var trade in trades)
{
    Console.WriteLine(expiredHandler.Handle(trade, trade.ReferenceDate));
}

Console.Read();