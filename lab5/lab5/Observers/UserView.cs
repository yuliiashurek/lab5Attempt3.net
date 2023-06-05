using lab5.Subjects;

namespace lab5.Observers;

public class UserView
{
    public void PrintToConsole(string name, Subject subject)
    {
        Console.WriteLine(name + " sees updated info: \n"  + subject.SubjectToString());
    }
}