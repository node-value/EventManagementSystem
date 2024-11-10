using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class UpdateEventCommand(IEventRepository repo, Event @event) : ICommand
{
    private Event? _oldEvent;

    public void Execute()
    {
        var e = repo.GetEventById(@event.Id);
        if (e == null) return;
        _oldEvent = Event.Clone(e);
        repo.UpdateEvent(@event);

    }
    
    public void Undo()
    {
        repo.UpdateEvent(_oldEvent);
    }
}