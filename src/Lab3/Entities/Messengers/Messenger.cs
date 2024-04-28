using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Messenger : IMessenger
{
    public Messenger(ILogger logger)
    {
        SavedMessages = new List<string>();
        Logger = logger;
    }

    public ILogger Logger { get; }
    public IList<string> SavedMessages { get; }

    public void WriteMessage(string message)
    {
        if (message != null)
        {
            SavedMessages.Add(message);
            Logger.WriteMessage(message);
        }
    }
}