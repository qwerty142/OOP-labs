using Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic
{
    public Topic(string name, IDestination destination)
    {
        Name = name;
        Destination = destination;
    }

    public IDestination Destination { get; }

    public string Name { get; }

    public void SendMessage(IMessage message)
    {
        Destination.SendMessage(message);
    }
}