using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleWriters;

public class WindowsConsoleWriter : IConsoleWriter
{
    public void Write(string? toWrite)
    {
        Console.WriteLine(toWrite);
    }

    public string? GetMessage()
    {
        return Console.ReadLine();
    }
}