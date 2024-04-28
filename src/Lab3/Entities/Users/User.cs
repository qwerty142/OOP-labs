using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User
{
    public User()
    {
        Messages = new List<MessageWithStatus>();
    }

    public IList<MessageWithStatus> Messages { get; }

    public void AddMessage(IMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Messages.Add(new MessageWithStatus(message.Title, message.Body, message.Priority, false));
    }

    public void ChangeMessageStatus(Message message)
    {
        (Messages.FirstOrDefault(elem => elem.Title == message.Title
                                         && elem.Body == message.Body
                                         && elem.Priority == message.Priority)
         ?? throw new ArgumentException("No such message")).
            ChangeStatus();
    }
}