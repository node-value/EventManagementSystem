using EventManagementSystem.EventManagementSystem.UI.CLI.Util;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class HelpCommand: ICommand, INonPersistentCommand
{
    public void Execute()
    {
        CliPrinter.PrintCommands();
    }

    public void Undo(){}
}