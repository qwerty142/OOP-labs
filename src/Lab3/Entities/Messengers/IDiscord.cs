namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public interface IDiscord
{
    public void ReceiveMessageToChat(string apiKey, long userId, string message);
    public bool CheckUser(long userId);
}