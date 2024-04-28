using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Discord : IDiscord
{
    private List<long> _bannedUsers;
    private Regex _apiFormat = new Regex("\\[a-z]+");
    public Discord(ILogger logger, IList<long> bannedUsers)
    {
        _bannedUsers = bannedUsers.ToList();
        Logger = logger;
    }

    public ILogger Logger { get; }
    public bool CheckUser(long userId)
    {
        if (_bannedUsers.Contains(userId))
        {
            return false;
        }

        return true;
    }

    public void ReceiveMessageToChat(string apiKey, long userId, string message)
    {
        if (message != null && CheckUser(userId) && _apiFormat.IsMatch(apiKey))
        {
            Logger.WriteMessage(message);
        }
    }
}