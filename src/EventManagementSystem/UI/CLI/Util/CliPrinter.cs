using EventManagementSystem.EventManagementSystem.Commands;
using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.UI.CLI.Util;

public static class CliPrinter
{

    public static void PrintEvent(Event? e)
    {
        Console.WriteLine(e is null
            ? "No event found"
            : $"\nID: {e.Id}\nName: {e.Name}\nDescription: {e.Description}\nDate: {DateOnly.FromDateTime(e.Date)}\nLocation: {e.Location}\n");
    }
    public static void PrintEvents(List<Event> events)
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events found");
        }
        events.ForEach(PrintEvent);
        
    }
    
    public static void PrintGreetings()
    {
        Console.WriteLine("Welcome to EventManagementSystem!");
    }

    public static void PrintCommands()
    {
        Console.WriteLine("Available Commands:");

        var commands = Enum.GetNames(typeof(ECommands));
        
        for (var i = 0; i < commands.Length; i++)
            Console.WriteLine($"{i + 1}. {commands[i].ToLower()}");
    }
}