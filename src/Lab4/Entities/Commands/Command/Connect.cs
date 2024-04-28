using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class Connect : ICommand
{
    private string _address;
    private string _mode;

    public Connect(string address, string mode)
    {
        _address = address;
        _mode = mode;
    }

    [SuppressMessage("", "IDE0059", Justification = "d")]
    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        // также к connect логика того что нельзя подконнектиться
        // когда уже законнекчено есть тут
        if (string.IsNullOrEmpty(currentFile.Path))
        {
            currentFile.Path = _address;
        }
        else
        {
            throw new TryConnectBeforeDisconnectException();
        }

        bool connectRes = false;
        switch (_mode)
        {
            case "local":
                connectRes = currentFile.FileSystem.Connect(_address);
                break;
            default:
                throw new WrongModeException();
        }

        if (connectRes)
        {
            return "Success";
        }

        return "Fail to connect";
    }
}