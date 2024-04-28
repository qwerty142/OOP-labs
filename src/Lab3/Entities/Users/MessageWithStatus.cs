using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class MessageWithStatus : IMessage
{
    public MessageWithStatus(string title, string body, int priority, bool readStatus)
    {
        Title = title;
        Body = body;
        Priority = priority;
        ReadStatus = readStatus;
    }

    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }
    public bool ReadStatus { get; private set; }

    public void ChangeStatus()
    {
        if (ReadStatus == true)
        {
            throw new ArgumentException("Unable to change status of read message");
        }

        ReadStatus = true;
    }
}