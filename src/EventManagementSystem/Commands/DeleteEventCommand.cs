using EventManagementSystem.EventManagementSystem.Model;
using EventManagementSystem.EventManagementSystem.Repository;

namespace EventManagementSystem.EventManagementSystem.Commands;

public class DeleteEventCommand : ICommand
{
    private readonly IEventRepository _repo;
    private Event? _event;

    public DeleteEventCommand(IEventRepository repo, int id)
    {
        _repo = repo;
        _event = _repo.GetEventById(id);
    }
    public void Execute()
    {
        if (_event != null)
        {
            _event = Event.Clone(_event);
            _repo.DeleteEvent(_event);
        }
    }
    
    public void Undo()
    {
        if (_event != null)
            _repo.SaveEvent(_event);
    }
}