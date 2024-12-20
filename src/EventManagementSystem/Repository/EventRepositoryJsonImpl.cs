﻿using EventManagementSystem.EventManagementSystem.Model;
using Newtonsoft.Json;

namespace EventManagementSystem.EventManagementSystem.Repository;

public class EventRepositoryJsonImpl : IEventRepository
{

    private List<Event> _events = [];
    private const string Path = "events.json";
    private Dictionary<int, Event> _eventsById;
    
    public EventRepositoryJsonImpl()
    {
        ReadAllEvents();
        _eventsById = _events.ToDictionary(e => e.Id, e => e);
    }
    
    private void ReadAllEvents()
    {
        if (!File.Exists(Path)) return;
        
        _events = JsonConvert.DeserializeObject<List<Event>>(
            File.ReadAllText(Path)) ?? [];
        Event.SetIdCounter(_events.Max(e => e.Id));

    }

    private void WriteAllEvents()
    {
        File.WriteAllText(Path, 
            JsonConvert.SerializeObject(_events, Formatting.Indented));
    }
         
    public Event? GetEventById(int id)
    {
        return _eventsById.GetValueOrDefault(id, null);
    }
    
    public List<Event> GetAllEvents()
    {
        return _events;
    }

    public void SaveEvent(Event @event)
    {
        _events.Add(@event);
        _eventsById.Add(@event.Id, @event);
        WriteAllEvents();
    }

    public void UpdateEvent(Event @event)
    {
        var eToUpdate = _eventsById.GetValueOrDefault(@event.Id, null);
        if (eToUpdate != null) {
            UpdateProperties(eToUpdate, @event);
            WriteAllEvents();
            return;
        }
        Console.WriteLine($"Event {@event.Id} was not found");
    }

    private static void UpdateProperties(Event eToUpdate, Event @event)
    {
        eToUpdate.Name = @event.Name;
        eToUpdate.Description = @event.Description;
        eToUpdate.Date = @event.Date;
        eToUpdate.Location = @event.Location;
    }

    public void DeleteEvent(Event @event)
    {
        var e = _events.Find(e => e.Id == @event.Id);
        if (e != null)
        {
            _events.Remove(e);
            _eventsById.Remove(@event.Id);
            WriteAllEvents();
        }
        else
        {
            Console.WriteLine($"Event with id: {@event.Id} was not found");
        }
    }
}