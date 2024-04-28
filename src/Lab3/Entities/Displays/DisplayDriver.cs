using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayType;

public class DisplayDriver : IDisplayDriver
{
    public string OutText { get; private set; } = string.Empty;
    public ConsoleColor Color { get; private set; }

    public void ClearMessage()
    {
        OutText = string.Empty;
    }

    public void SetColor(ConsoleColor color)
    {
        Color = color;
    }

    public void AddMessage(string message)
    {
        OutText = message;
    }

    public string GetMessage()
    {
        Console.ForegroundColor = Color;
        return OutText;
    }
}