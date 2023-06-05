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
    
    private readonly MainController _controller;

    public MainModel(MainController controller)
    {
        _controller = controller;
        _commandsAndHistory = new CommandsAndHistory();
    }

    public void CreateSubjUserSubsciptions()
    {
        CreateSubjects();
        CreateUsers();
        AddingSubscriptions();
        CreatesAndFillCommandAndHistory();
        ChangeDemo();
    }


    private void CreateSubjects()
    {
        CurrencyRates currencyRates = new CurrencyRates(new WorkWithXml());
        GovernmentBondStockQuote governmentBondStockQuote =
            new GovernmentBondStockQuote(1323146884.35, WayOfPaying.PostPaid);
        NaturalGasStockQuotes naturalGasStockQuotes =
            new NaturalGasStockQuotes(10708.35, DeliveryConditions.Gts);
        _subjectsList =  new List<Subject>() { currencyRates, governmentBondStockQuote, naturalGasStockQuotes };
        _controller.UpdateViewSubjectList(_subjectsList);
    }

    private void CreateUsers()
    {
        UserView userView = new UserView();
        User user1 = new User("user1", UserController.GetInstance(userView));
        User user2 = new User("user2", UserController.GetInstance(userView));
        _users = new List<IObserver>() { user1, user2 };
    }

    private void CreatesAndFillCommandAndHistory()
    {
        _controller.PrintConsole(
            "Enter a number n (added to governmentBond, naturalGas'll increase in n percentages):");
        double number = _controller.ReadDouble();
        _commandsAndHistory.SetCommand(CommandsEnum.IncreaseGovPrice, new IncreasePriceCommand((StockQuotes)_subjectsList![1], number));
        _commandsAndHistory.SetCommand(CommandsEnum.IncreaseNatGasPercentage, new IncreasePriceByPercentageCommand((StockQuotes)_subjectsList[2], number));
    }
    
    private void ChangeDemo()
    {
        _commandsAndHistory.PressIncrease(CommandsEnum.IncreaseGovPrice);
        _commandsAndHistory.PressIncrease(CommandsEnum.IncreaseNatGasPercentage);
        _commandsAndHistory.PressUndo();
    }

    private void AddingSubscriptions()
    {
        _users![0].AddSubscription(_subjectsList![0]);
        _subjectsList[1].RegisterObserver(_users[0]);
        _users[1].AddSubscription(_subjectsList[2]);
    }
}