﻿using EventManagementSystem.EventManagementSystem.Commands;

namespace EventManagementSystem.EventManagementSystem.Controllers;

public class CommandController
{
    private readonly Stack<ICommand> _commandHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        
        if (command is not INonPersistentCommand) 
            _commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}