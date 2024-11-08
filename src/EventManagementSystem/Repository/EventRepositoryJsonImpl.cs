using EventManagementSystem.EventManagementSystem.Model;
using Newtonsoft.Json;

namespace EventManagementSystem.EventManagementSystem.Repository;

public class EventRepositoryJsonImpl : IEventRepository
{

    private List<Event> _events = [];
    private const string Path = "events.json";
    private Dictionary<Guid, Event> _eventsById;
    private Dictionary<DateTime, List<Event>> _eventsByDate;
    
    public EventRepositoryJsonImpl()
    {
        ReadAllEvents();
        _eventsById = _events.ToDictionary(e => e.Id, e => e);
        _eventsByDate = MapEventsByDate();
    }

    private Dictionary<DateTime, List<Event>> MapEventsByDate()
    {
        var result = _events
            .Select(e => e.Date)
            .ToHashSet()
            .ToDictionary(d => d, _ => new List<Event>());
        
        _events.ForEach(e => result[e.Date].Add(e));
        
        return result;
    }
    
    private void ReadAllEvents()
    {
        if (File.Exists(Path))
            _events = JsonConvert.DeserializeObject<List<Event>>(
                File.ReadAllText(Path)) ?? [];
    }

    private void WriteAllEvents()
    {
        File.WriteAllText(Path, 
            JsonConvert.SerializeObject(_events, Formatting.Indented));
    }
         
    public Event? GetEventById(Guid id)
    {
        return _eventsById.GetValueOrDefault(id, null);
    }

    public List<Event> GetEventsByDate(DateTime date)
    {
        return _eventsByDate.GetValueOrDefault(date, []);
    }

    public List<Event> GetAllEvents()
    {
        return _events;
    }

    public Event? SaveEvent(Event @event)
    {
        _events.Add(@event);
        WriteAllEvents();
        return @event;
    }

    public Event? UpdateEvent(Event @event)
    {
        var eToUpdate = _eventsById[@event.Id];
        if (@event.Date != eToUpdate.Date)
        {
            UpdateProperties(eToUpdate, @event);
            MapEventsByDate();
            return eToUpdate;
        }
        UpdateProperties(eToUpdate, @event);
        return eToUpdate;
    }

    private void UpdateProperties(Event eToUpdate, Event @event)
    {
        eToUpdate.Name = @event.Name;
        eToUpdate.Description = @event.Description;
        eToUpdate.Date = @event.Date;
        eToUpdate.Location = @event.Location;
    }

    public void DeleteEvent(Event @event)
    {
        _events.Remove(@event);
        _eventsById.Remove(@event.Id);
        _eventsByDate[@event.Date].Remove(@event);
    }
}