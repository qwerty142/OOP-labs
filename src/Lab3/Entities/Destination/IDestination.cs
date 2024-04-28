using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination;

public interface IDestination
{
    public void SendMessage(IMessage message);
}