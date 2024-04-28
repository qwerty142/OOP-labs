using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class FileMove : ICommand
{
    private string _source;
    private string _destination;

    public FileMove(string source, string destination)
    {
        _source = source;
        _destination = destination;
    }

    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        currentFile.FileSystem.FileMove(_source, _destination);
        return "Success";
    }
}