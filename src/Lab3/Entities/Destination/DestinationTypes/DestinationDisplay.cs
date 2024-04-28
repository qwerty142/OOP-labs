using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationTypes;

public class DestinationDisplay : IDestination
{
    public DestinationDisplay(IDisplay display)
    {
        Display = display;
    }

    public IDisplay Display { get; }
    public void SendMessage(IMessage message)
    {
        if (message != null) Display.WriteMessage(message.Body);
    }
}