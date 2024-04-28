using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationAdapter;

public class LoggerDecorator : IDestination
{
    public LoggerDecorator(IDestination destination, ILogger logger)
    {
        Destination = destination;
        Logger = logger;
    }

    public IDestination Destination { get; }
    public ILogger Logger { get; }

    public void SendMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Logger.WriteMessage(message.Body);
        Destination.SendMessage(message);
    }
}