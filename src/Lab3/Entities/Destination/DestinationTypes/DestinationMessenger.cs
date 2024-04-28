using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationTypes;

public class DestinationMessenger : IDestination
{
    public DestinationMessenger(IMessenger messenger)
    {
        Messenger = messenger;
    }

    public IMessenger Messenger { get; }
    public void SendMessage(IMessage message)
    {
        if (message != null) Messenger.WriteMessage(message.Body);
    }
}