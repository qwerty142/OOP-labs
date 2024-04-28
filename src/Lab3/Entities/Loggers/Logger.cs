using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class Logger : ILogger
{
    public void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
}