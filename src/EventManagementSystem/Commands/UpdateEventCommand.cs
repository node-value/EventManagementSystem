using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class UpdateEventCommand(IEventRepository repo, Event @event) : ICommand
{
    private Event? _oldEvent;

    public void Execute()
    {
        _oldEvent = @event.Clone();
        repo.UpdateEvent(@event);
    }
    
    public void Undo()
    {
        repo.UpdateEvent(_oldEvent);
    }
}