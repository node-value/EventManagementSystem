namespace EventManagementSystem.EventManagementSystem.Commands;

public interface ICommand
{
    void Execute();
    void Undo();

    void Redo() { Execute(); }
}