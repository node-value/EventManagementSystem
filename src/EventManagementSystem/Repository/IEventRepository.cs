using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.Repository;

public interface IEventRepository
{    public Event? GetEventById(Guid id);
     
     public List<Event> GetEventsByDate(DateTime date);
     
     public List<Event> GetAllEvents();
     
     public Event? SaveEvent(Event @event);
     
     public Event? UpdateEvent(Event @event);
     
     public void DeleteEvent(Event @event);

}