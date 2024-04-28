using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayType;

public class Display : IDisplay
{
    private ILogger _logger;

    private IDisplayDriver _displayDriver;
    public Display(ILogger logger, IDisplayDriver displayDriver)
    {
        _logger = logger;
        _displayDriver = displayDriver;
    }

    public void WriteMessage(string message)
    {
        _displayDriver.ClearMessage();
        _displayDriver.AddMessage(message);
        _displayDriver.SetColor(default);
        _logger.WriteMessage(_displayDriver.GetMessage());
    }

    public void WriteMessage(string message, ConsoleColor color)
    {
        _displayDriver.ClearMessage();
        _displayDriver.AddMessage(message);
        _displayDriver.SetColor(color);
        _logger.WriteMessage(_displayDriver.GetMessage());
    }
}