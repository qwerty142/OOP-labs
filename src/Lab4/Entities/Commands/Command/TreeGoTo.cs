using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class TreeGoTo : ICommand
{
    private string _path;

    public TreeGoTo(string path)
    {
        _path = path;
    }

    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        currentFile.FileSystem.ChangePath(_path, currentFile);
        return "Success";
    }
}