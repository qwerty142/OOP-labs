namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface ITelegram
{
    public void SendToChat(string login, string password, string message);
    public bool CheckUser(string user, string password);
}