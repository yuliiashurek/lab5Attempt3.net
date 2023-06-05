using lab5.Subjects;

namespace lab5;

public class MainController
{
    private static MainController? _instance;
    private static readonly object Lock = new();

    private readonly MainView _userView;

    private MainController(MainView userView)
    {
        _userView = userView;
    }

    public void UpdateViewSubjectList(List<Subject>? subjects)
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
    
    
    public static MainController GetInstance(MainView userView)
    {
        if (_instance != null) return _instance;
        lock (Lock)
        {
            _instance ??= new MainController(userView);
        }

        return _instance;
    }
}
