using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationTypes;

public class DestinationGroup : IDestination
{
    public DestinationGroup(IList<IDestination> destinations)
    {
        Destinations = destinations;
    }

    public IList<IDestination> Destinations { get; }
    public void SendMessage(IMessage message)
    {
        foreach (IDestination destination in Destinations)
        {
            if (message != null)
            {
                destination.SendMessage(message);
            }
        }
    }
}