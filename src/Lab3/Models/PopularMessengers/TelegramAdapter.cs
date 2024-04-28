using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.PopularMessengers;

public class TelegramAdapter : IMessenger
{
    private ITelegram _telegram;
    private string _login;
    private string _password;

    public TelegramAdapter(ITelegram telegram, string login, string password)
    {
        _telegram = telegram;
        _password = password;
        _login = login;
    }

    public void WriteMessage(string message)
    {
        _telegram.SendToChat(_login, _password, message);
    }
}