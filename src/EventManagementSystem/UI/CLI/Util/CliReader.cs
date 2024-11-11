using EventManagementSystem.EventManagementSystem.Commands;
using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.UI.CLI.Util;

public static class CliReader
{
    public static ECommands ReadCommand()
    {
        while (true)
        {
            var input = Console.ReadLine().Trim().ToLower();

            if (CliValidator.ValidateCommand(input))
                return (ECommands)Enum.Parse(typeof(ECommands), input, ignoreCase:true);
            
            Console.WriteLine("Invalid Command, please use command number or it's name.");
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
                "Enter Name: ", 
                CliValidator.ValidateEventName, 
                "event Name must be between 1 and 32 characters, no special characters are allowed."),
            
            Description = ReadInputLine(
                "Enter Description: ",
                CliValidator.ValidateEventDescription,
                "description must be between 0 and 512 characters, no special characters are allowed."),
            
            Date = DateTime.Parse(ReadInputLine(
                "Enter Event Date (dd-mm-yyyy): ",
                CliValidator.ValidateEventDate,
                "enter date in valid format: dd-mm-yyyy")),
            
            Location = ReadInputLine(
                "Enter Location: ",
                CliValidator.ValidateEventLocation,
                "no validation here yet.")
        };
    }
}