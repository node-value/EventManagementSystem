using System.Windows.Input;
using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;
using EventManagementSystem.EventManagementSystem.UI.CLI.Util;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class GetAllCommand(IEventRepository repo) : ICommand
{
    public void Execute()
    {
        CliPrinter.PrintEvents(repo.GetAllEvents());
    }
    
    public void Undo()
    { 
        Console.WriteLine("GetAll: Nothing to undo");
    }
}