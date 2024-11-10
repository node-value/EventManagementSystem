using EventManagementSystem.EventManagementSystem.Commands;
using EventManagementSystem.EventManagementSystem.Controllers;
using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;
using EventManagementSystem.EventManagementSystem.UI.CLI.Util;

namespace EventManagementSystem.EventManagementSystem.UI.TUI;

public class CommandLineInterface(CommandController commandController, IEventRepository repo): IUserInterface
{
    private readonly Dictionary<ECommands, Func<ICommand>> _commandMap = new()
    {
        { ECommands.GetAll, () => new GetAllCommand(repo) },
        { ECommands.Get, () => new GetCommand(repo, CliReader.ReadEventId()) },
        { ECommands.Add, () => new AddEventCommand(repo, CliReader.ReadEvent()) },
        { ECommands.Delete, () => new DeleteEventCommand(repo, CliReader.ReadEventId()) },
        { ECommands.Update, () => 
            {
                var id = CliReader.ReadEventId();
                var e = CliReader.ReadEvent();
                e.Id = id;
                return new UpdateEventCommand(repo, e);
            }
        },
        { ECommands.Exit, () => new ExitCommand()}
    };

    public void Run()
    {
        CliPrinter.PrintGreetings();
        while (true)
        {
            var command = CliReader.ReadCommand();
            if (command == ECommands.Undo)
            {
                commandController.UndoLastCommand();
            }
            else
            {
                commandController.ExecuteCommand(_commandMap[command].Invoke());
            }
        }
    }
}