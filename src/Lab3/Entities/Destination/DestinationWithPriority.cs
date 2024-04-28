using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination;

public class DestinationWithPriority : IDestination
{
    public DestinationWithPriority(IDestination destination, int priority)
    {
        Destination = destination;
        Priority = priority;
    }

    public IDestination Destination { get; }

    public int Priority { get; }

    public void SendMessage(IMessage message)
    {
        if (message != null && message.Priority >= Priority)
        {
            Destination.SendMessage(message);
        }
    }
}