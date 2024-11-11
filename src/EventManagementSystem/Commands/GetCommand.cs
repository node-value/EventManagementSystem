using EventManagementSystem.EventManagementSystem.Repository;
using EventManagementSystem.EventManagementSystem.UI.CLI.Util;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class GetCommand(IEventRepository repo, int id) : ICommand, INonPersistentCommand
{
    public void Execute()
    {
        CliPrinter.PrintEvent(repo.GetEventById(id));
    }
    
    public void Undo()
    { 
        Console.WriteLine("Get: Nothing to undo");
    }
    
}