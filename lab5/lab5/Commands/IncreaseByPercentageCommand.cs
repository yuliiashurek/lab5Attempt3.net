using lab5.Subjects.Stock;

namespace lab5.Commands;

public class IncreasePriceByPercentageCommand : ICommand
{
    private readonly StockQuotes _stockQuotes;
    private readonly double _increasePercentage;

    public IncreasePriceByPercentageCommand(StockQuotes stockQuotes, double increasePercentage)
    {
        _stockQuotes = stockQuotes;
        _increasePercentage = increasePercentage;
    }

    public void Execute()
    {
        _stockQuotes.SetNewQuotedPrice(_stockQuotes.QuotedPrice * (100 + _increasePercentage) / 100);
    }

    public void Undo()
    {
        _stockQuotes.SetNewQuotedPrice(_stockQuotes.QuotedPrice*100 / (100 + _increasePercentage));
    }
}