namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleWriters;

public interface IConsoleWriter
{
    public void Write(string? toWrite);
    public string? GetMessage();
}