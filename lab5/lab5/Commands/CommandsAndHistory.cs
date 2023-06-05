namespace lab5.Commands;

public class CommandsAndHistory
{
    private readonly Stack<ICommand> _history;
    private readonly Dictionary<CommandsEnum, ICommand> _commands;

    public CommandsAndHistory()
    {
        _history = new Stack<ICommand>();
        _commands = new Dictionary<CommandsEnum, ICommand>();
    }

    public void SetCommand(CommandsEnum commandsEnum, ICommand command)
    {
        _commands[commandsEnum] = command;
    }

    public void PressIncrease(CommandsEnum commandEnum)
    {
        ICommand command = _commands[commandEnum];
        command.Execute();
        _history.Push(command);
    }

    public void PressUndo()
    {
        if (_history.Count != 0)
        {
            ICommand command = _history.Pop();
            command.Undo();
        }
    }
}