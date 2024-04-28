using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class FileShow : ICommand
{
    private string _path;
    private string _mode;

    public FileShow(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        string inFile;
        switch (_mode)
        {
            case "local":
                inFile = currentFile.FileSystem.FileShow(_path);
                break;
            default:
                throw new WrongModeException();
        }

        return inFile;
    }
}