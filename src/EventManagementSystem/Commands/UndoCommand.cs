using EventManagementSystem.EventManagementSystem.Controllers;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class UndoCommand(CommandController controller): ICommand, INonPersistentCommand
{
    public void Execute()
    {
        controller.UndoLastCommand();
    }

    public void Undo() { }
}