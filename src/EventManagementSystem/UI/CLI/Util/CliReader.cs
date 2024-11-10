using EventManagementSystem.EventManagementSystem.Commands;
using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.UI.CLI.Util;

public static class CliReader
{
    public static ECommands ReadCommand()
    {
        while (true)
        {
            CliPrinter.PrintCommands();
            var input = Console.ReadLine().Trim().ToLower();

            if (CliValidator.ValidateCommandNumber(input))
                return (ECommands)Enum.Parse(typeof(ECommands), input);
            
            Console.WriteLine("Invalid Command, please use command number");
        }
    }

    private static string ReadInputLine(string msg, Predicate<string> isValid, string msgIfInvalid)
    {
        while (true)
        {
            Console.Write(msg);
            var input = Console.ReadLine().Trim();
            
            if (isValid(input)) return input;
            
            Console.WriteLine($"Invalid input, {msgIfInvalid}");
        }
    }

    public static int ReadEventId()
    {
        return int.Parse(ReadInputLine("Please enter an ID of the Event: ",
            CliValidator.ValidateEventId,
            "invalid ID"));
    }
    
    public static Event ReadEvent()
    {
        return new Event
        {
            Name = ReadInputLine(
                "Please enter name: ", 
                CliValidator.ValidateEventName, 
                "event Name must be between 1 and 32 characters, no special characters are allowed."),
            
            Description = ReadInputLine(
                "Please enter description: ",
                CliValidator.ValidateEventDescription,
                "description must be between 0 and 512 characters, no special characters are allowed."),
            
            Date = DateTime.Parse(ReadInputLine(
                "Please enter event date (dd-mm-yyyy): ",
                CliValidator.ValidateEventDate,
                "enter date in valid format: dd-mm-yyyy")),
            
            Location = ReadInputLine(
                "Please enter location: ",
                CliValidator.ValidateEventLocation,
                "no validation here yet.")
        };
    }
}