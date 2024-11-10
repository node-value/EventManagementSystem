using EventManagementSystem.EventManagementSystem.Model;

namespace EventManagementSystem.EventManagementSystem.Repository;

public interface IEventRepository
{    
     Event? GetEventById(int id); 
     
     List<Event> GetAllEvents();
     
     void SaveEvent(Event @event);
     
     void UpdateEvent(Event @event);
     
     void DeleteEvent(Event @event);

}