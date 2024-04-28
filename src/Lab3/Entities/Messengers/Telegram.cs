using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class Telegram : ITelegram
{
    private IList<TelegrammUser> _telegrammUsers;
    public Telegram(ILogger logger, IList<TelegrammUser> users)
    {
        _telegrammUsers = users;
        Logger = logger;
    }

    public ILogger Logger { get; }

    public bool CheckUser(string user, string password)
    {
        var currentUser = new TelegrammUser(user, password);
        if (_telegrammUsers.Contains(currentUser))
        {
            return true;
        }

        return false;
    }

    public void SendToChat(string login, string password, string message)
    {
        if (message != null && CheckUser(login, password))
        {
            Logger.WriteMessage(message);
        }
    }
}