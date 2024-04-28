using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class ConnectHandler : ChainLinkBase
{
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);
        string[] options = command.Split(' ');
        if (options[0] == "connect" && options.Length == 3)
        {
            return new Connect(options[1], options[2]);
        }

        return ParseNext(command);
    }
}