using lab5.Subjects;

namespace lab5.Observers;

public interface IObserver
{
    public string UserName { get; }
    public void Update(Subject subject);
    public bool AddSubscription(Subject subject);
    public bool RemoveSubscription(Subject subject);
}