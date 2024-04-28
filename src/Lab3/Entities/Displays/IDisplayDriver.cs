using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    public void ClearMessage();

    public void SetColor(ConsoleColor color);

    public void AddMessage(string message);

    public string GetMessage();
}