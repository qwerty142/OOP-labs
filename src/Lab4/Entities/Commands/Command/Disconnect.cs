using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class Disconnect : ICommand
{
    public string Run(IContext currentFile)
    {
        ArgumentNullException.ThrowIfNull(currentFile);
        return currentFile.FileSystem.Disconnect();
    }
}