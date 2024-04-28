using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class FacadeTopic
{
    private IList<Topic> _topics;

    public FacadeTopic()
    {
        _topics = new List<Topic>();
    }

    public void AddTopic(Topic topic)
    {
        _topics.Add(topic);
    }

    public void SendMessage(string topicName, IMessage message)
    {
        (_topics.FirstOrDefault(var => var.Name == topicName) ??
         throw new ArgumentException("No such topic"))
            .SendMessage(message);
    }
}