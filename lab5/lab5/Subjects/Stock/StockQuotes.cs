namespace lab5.Subjects.Stock;

public abstract class StockQuotes : Subject
{
    public double QuotedPrice { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public double PercentageDifference { get; private set; }

    protected StockQuotes(string name,double quotedPrice) : base(name)
    {
        QuotedPrice = quotedPrice;
        LastUpdated = DateTime.Now;
        PercentageDifference = 0;
    }
    
    public void SetNewQuotedPrice(double newQuotedPrice)
    {
        PercentageDifference = ((newQuotedPrice * 100) / QuotedPrice) - 100;
        QuotedPrice = newQuotedPrice;
        LastUpdated = DateTime.Now;
        NotifyObservers();
    }
    // public double GetQuotedPrice()
    // {
    //     return QuotedPrice;
    // }
    
}