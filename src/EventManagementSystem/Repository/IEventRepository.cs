using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.Repository;

public interface IEventRepository
{    
     Event? GetEventById(int id); 
     
     List<Event> GetAllEvents();
     
     Event? SaveEvent(Event @event);
     
     Event? UpdateEvent(Event @event);
     
     void DeleteEvent(Event @event);

}