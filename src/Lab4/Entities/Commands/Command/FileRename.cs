using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class FileRename : ICommand
{
    private string _path;
    private string _name;

    public FileRename(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        currentFile.FileSystem.FileRename(_path, _name);
        return "Success";
    }
}