using lab5.Subjects.Currency.XmlCurrency;
using Timer = System.Threading.Timer;

namespace lab5.Subjects.Currency;

public class CurrencyRates : Subject
{
    public List<ICurrencyInfo> CurrencyInfos { get; private set; }
    private readonly WorkWithXml _workWithXml;
    private Timer _timer;


    public CurrencyRates(WorkWithXml workWithXml, string name = "Currency Rates") : base(name)
    {
       _workWithXml = workWithXml;
        CurrencyInfos = _workWithXml.CurrencyInfos;
        _timer = new Timer(TimerElapsed, null, 0, 1000);
    }

    private void TimerElapsed(object? state)
    {
        (bool hasChanged, List<ICurrencyInfo>? currencyInfoListFromXml) = _workWithXml.Reload();
        if (hasChanged)
        {
            CurrencyInfos = currencyInfoListFromXml!;
            NotifyObservers();
        }
    }

}