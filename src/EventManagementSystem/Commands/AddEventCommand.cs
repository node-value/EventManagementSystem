using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class AddEventCommand(IEventRepository repo, Event @event) : ICommand
{
    public void Execute()
    {
        repo.SaveEvent(@event);
    }
    
    public void Undo()
    {
        repo.DeleteEvent(@event);
    }
    
}