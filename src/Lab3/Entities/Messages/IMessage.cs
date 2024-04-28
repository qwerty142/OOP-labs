namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessage
{
    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }
}