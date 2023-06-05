namespace lab5.Subjects.Stock;

public class GovernmentBondStockQuote : StockQuotes
{
    private WayOfPaying WayOfPaying { get; }

    public GovernmentBondStockQuote(double quotedPrice, WayOfPaying wayOfPaying)
        : base("Government Bond", quotedPrice)
    {
        WayOfPaying = wayOfPaying;
    }
}