using lab5.Subjects.Stock;

namespace lab5.Commands;

public class IncreasePriceCommand : ICommand
{
    private readonly StockQuotes _stockQuotes;
    private readonly double _increaseNum;

    public IncreasePriceCommand(StockQuotes stockQuotes, double increaseNum)
    {
        _stockQuotes = stockQuotes;
        _increaseNum = increaseNum;
    }

    public void Execute()
    {
        _stockQuotes.SetNewQuotedPrice(_stockQuotes.QuotedPrice + _increaseNum);
    }

    public void Undo()
    {
        _stockQuotes.SetNewQuotedPrice(_stockQuotes.QuotedPrice - _increaseNum);
    }
}