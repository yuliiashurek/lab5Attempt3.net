using lab5.Subjects;

namespace lab5.Observers;

public sealed class UserController
{
    
    private static UserController? _instance;
    private static readonly object Lock = new();

    private readonly UserView _userView;

    private UserController(UserView userView)
    {
        _userView = userView;
    }

    
    public void UpdateView(string name, Subject subject)
    {
        _userView.PrintToConsole(name, subject);
    }
    
    
    public static UserController GetInstance(UserView userView)
    {
        if (_instance != null) return _instance;
        lock (Lock)
        {
            _instance ??= new UserController(userView);
        }

        return _instance;
    }
}
