using lab5.Subjects;

namespace lab5;

public class MainView
{
    public void PrintToConsoleSubjectList(List<Subject>? list)
    {
        foreach (var sub in list)
        {
            Console.WriteLine(sub.SubjectToString());
        }
    }

    public void PrintConsole(string str)
    {
        Console.WriteLine(str);
    }

    public string? ReadConsole()
    {
        return Console.ReadLine();
    }
}