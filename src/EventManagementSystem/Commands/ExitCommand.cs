namespace EventManagementSystem.EventManagementSystem.Commands;

public class ExitCommand: ICommand, INonPersistentCommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }

    public void Undo() { }
}