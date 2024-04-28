using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.PopularMessengers;

public class DiscordAdapter : IMessenger
{
    private IDiscord _discord;
    private string _apiKey;
    private long _userId;
    public DiscordAdapter(IDiscord discord, string apiKey, long userId)
    {
        _userId = userId;
        _apiKey = apiKey;
        _discord = discord;
    }

    public void WriteMessage(string message)
    {
        _discord.ReceiveMessageToChat(_apiKey, _userId, message);
    }
}