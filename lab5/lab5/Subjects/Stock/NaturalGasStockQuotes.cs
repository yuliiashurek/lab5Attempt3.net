namespace lab5.Subjects.Stock;

public class NaturalGasStockQuotes: StockQuotes
{
    private DeliveryConditions DeliveryConditions { get; }

    public NaturalGasStockQuotes( double quotedPrice, DeliveryConditions deliveryConditions)
        : base("Natural Gas", quotedPrice)
    {
        DeliveryConditions = deliveryConditions;
    }
}