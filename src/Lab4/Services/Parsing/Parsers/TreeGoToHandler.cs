using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class TreeGoToHandler : ChainLinkBase
{
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);

        string[] options = command.Split(' ');

        if (options[0] == "treegoto" && options.Length == 2)
        {
            return new TreeGoTo(options[1]);
        }

        return ParseNext(command);
    }
}