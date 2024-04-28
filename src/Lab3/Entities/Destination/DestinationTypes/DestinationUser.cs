using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Destination.DestinationTypes;

public class DestinationUser : IDestination
{
    public DestinationUser(User user)
    {
        User = user;
    }

    public User User { get; }

    public void SendMessage(IMessage message)
    {
        if (message != null)
        {
            User.AddMessage(message);
        }
    }
}