using lab5.Commands;
using lab5.Observers;
using lab5.Subjects;
using lab5.Subjects.Currency;
using lab5.Subjects.Currency.XmlCurrency;
using lab5.Subjects.Stock;

namespace lab5;

public class MainModel
{
    private List<IObserver>? _users;
    private List<Subject>? _subjectsList;
    private readonly CommandsAndHistory _commandsAndHistory;
    
    // private readonly MainController _controller;

    public MainModel()
    {
        _commandsAndHistory = new CommandsAndHistory();
    }

    public List<Subject> CreateSubjects()
    {
        CurrencyRates currencyRates = new CurrencyRates(new WorkWithXml());
        GovernmentBondStockQuote governmentBondStockQuote =
            new GovernmentBondStockQuote(1323146884.35, WayOfPaying.PostPaid);
        NaturalGasStockQuotes naturalGasStockQuotes =
            new NaturalGasStockQuotes(10708.35, DeliveryConditions.Gts);
        _subjectsList =  new List<Subject>() { currencyRates, governmentBondStockQuote, naturalGasStockQuotes };
        return _subjectsList;
    }

    public List<IObserver> CreateUsers()
    {
        UserView userView = new UserView();
        User user1 = new User("user1", UserController.GetInstance(userView));
        User user2 = new User("user2", UserController.GetInstance(userView));
        _users = new List<IObserver>() { user1, user2 };
        return _users;
    }

    public void CreatesAndFillCommandAndHistory(double number)
    {
        _commandsAndHistory.SetCommand(CommandsEnum.IncreaseGovPrice, new IncreasePriceCommand((StockQuotes)_subjectsList![1], number));
        _commandsAndHistory.SetCommand(CommandsEnum.IncreaseNatGasPercentage, new IncreasePriceByPercentageCommand((StockQuotes)_subjectsList[2], number));
    }

    public void ChangeDemo()
    {
        _commandsAndHistory.PressIncrease(CommandsEnum.IncreaseGovPrice);
        _commandsAndHistory.PressIncrease(CommandsEnum.IncreaseNatGasPercentage);
        _commandsAndHistory.PressUndo();
    }

    public void AddingSubscriptions()
    {
        _users![0].AddSubscription(_subjectsList![0]);
        _subjectsList[1].RegisterObserver(_users[0]);
        _users[1].AddSubscription(_subjectsList[2]);
    }
}
