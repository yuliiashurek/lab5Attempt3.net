using lab5.Observers;

namespace lab5.Subjects;

public abstract class Subject
{
    public string Name { get; }
    private readonly List<IObserver> _observers;

    protected Subject(string name)
    {
        _observers = new List<IObserver>();
        Name = name;
    }

    public bool RegisterObserver(IObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
            return true;
        }
        return false;
    }

    public bool RemoveObserver(IObserver observer)
    {
        if (_observers.Contains(observer))
        {
            _observers.Remove(observer);
            return true;
        }

        return false;
    }


    protected void NotifyObservers()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}