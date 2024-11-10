// See https://aka.ms/new-console-template for more information

using EventManagementSystem.EventManagementSystem.Controllers;
using EventManagementSystem.EventManagementSystem.Repository;
using EventManagementSystem.EventManagementSystem.UI.TUI;

internal class Program
{
    public static void Main(string[] args)
    {
        new CommandLineInterface(new CommandController(), new EventRepositoryJsonImpl()).Run();
    }
}