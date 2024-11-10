namespace EventManagementSystem.EventManagementSystem.Model;

public class Event
{
    private int _id = 1;
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string? Location { get; set; } = string.Empty;

    public Event()
    {
        Id = _id++;
    }
    
    public Event Clone()
    {
        return new Event
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Date = this.Date,
            Location = this.Location
        };
    }
}