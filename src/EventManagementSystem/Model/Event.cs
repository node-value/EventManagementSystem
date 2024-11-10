namespace EventManagementSystem.EventManagementSystem.Model;

public class Event
{
    private static int _id = 1;
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Location { get; set; } = string.Empty;

    public Event()
    {
        Id = _id++;
    }
    
    public static void SetIdCounter(int maxId)
    {
        _id = maxId + 1;
    }
    
    public static Event Clone(Event source)
    {
        return new Event
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            Date = source.Date,
            Location = source.Location
        };
    }
}