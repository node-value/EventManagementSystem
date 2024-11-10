namespace EventManagementSystem.EventManagementSystem.Commands;

public class ExitCommand: ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }

    public void Undo()
    {
        
    }
}