using EventManagementSystem.EventManagementSystem.Commands;

namespace EventManagementSystem.EventManagementSystem.UI.CLI.Util;

public static class CliValidator
{
    public static bool ValidateCommand(string input)
    {
        if (int.TryParse(input, out var number))
            return number >= 1 && number <= Enum.GetNames(typeof(ECommands)).Length;
        
        return Enum.TryParse<ECommands>(input, ignoreCase: true, out _);
    }

    public static bool ValidateEventName(string input)
    {
        return input.Length is > 0 and < 32 
               && input.All(c => char.IsLetterOrDigit(c) || c == ' ' || c == '_' || c == '-');
    }

    public static bool ValidateEventDescription(string input)
    {
        return input.Length < 512;
    }

    public static bool ValidateEventDate(string input)
    {
        const string format = "dd-MM-yyyy";
        return DateTime.TryParseExact(
            input,
            format,
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out var parsedDate
        );
    }
    
    public static bool ValidateEventLocation(string input)
    {
        return true;
    }
    
    public static bool ValidateEventId(string input)
    {
        if (int.TryParse(input, out var number))
            return number > 0;
        
        return false;
    }
}