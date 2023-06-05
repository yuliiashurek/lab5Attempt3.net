using lab5.Subjects;

namespace lab5.Observers;

public class User : IObserver
{
    public string UserName { get; }
    private UserController UserController { get; }

    public User(string userName, UserController userController)
    {
        UserName = userName;
        UserController = userController;
    }
    public bool AddSubscription(Subject subject)
    {
        return subject.RegisterObserver(this);
    }
    public bool RemoveSubscription(Subject subject)
    {
        return subject.RemoveObserver(this);
    }
    
    public void Update(Subject subject)
    {
        UserController.UpdateView(UserName, subject);
    }
}