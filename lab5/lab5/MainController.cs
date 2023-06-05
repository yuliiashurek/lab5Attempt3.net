using lab5.Subjects;

namespace lab5;

public class MainController
{
    private static MainController? _instance;
    private static readonly object Lock = new();

    private readonly MainView _userView;
    private readonly MainModel _userModel;

    private MainController(MainView userView, MainModel userModel)
    {
        _userView = userView;
        _userModel = userModel;
    }

    
    public void CreateSubjUserSubsciptions()
    {
        UpdateViewSubjectList(_userModel.CreateSubjects());
        _userModel.CreateUsers();
        _userModel.AddingSubscriptions();
        CreatesAndFillCommandAndHistory();
        _userModel.ChangeDemo();
    }
    
    private void CreatesAndFillCommandAndHistory()
    {
        PrintConsole(
            "Enter a number n (added to governmentBond, naturalGas'll increase in n percentages):");
        double number = ReadDouble();
        _userModel.CreatesAndFillCommandAndHistory(number);
    }
    
    public void UpdateViewSubjectList(List<Subject> subjects)
    {
        _userView.PrintToConsoleSubjectList(subjects);
    }
    
    public void PrintConsole(string str)
    {
        _userView.PrintConsole(str);
    }

    public double ReadDouble()
    {
        string? str= _userView.ReadConsole();
        if (str != null) return double.Parse(str);
        return 0;
    }
    
    
    public static MainController GetInstance(MainView userView, MainModel mainModel)
    {
        if (_instance != null) return _instance;
        lock (Lock)
        {
            _instance ??= new MainController(userView, mainModel);
        }

        return _instance;
    }
}
