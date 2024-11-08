using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.Repository;

public interface IEventRepository
{    public Event? GetEventById(int id);
     
     public List<Event> GetEventsByDate(DateTime date);
     
     public List<Event> GetAllEvents();
     
     public Event? SaveEvent(Event @event);
     
     public Event? UpdateEvent(Event @event);
     
     public Event? DeleteEvent(Event @event);

}