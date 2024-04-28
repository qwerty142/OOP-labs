using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class FileDeleteHandler : ChainLinkBase
{
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);

        string[] options = command.Split(' ');

        if (options[0] == "delete" && options.Length == 2)
        {
            return new FileDelete(options[1]);
        }

        return ParseNext(command);
    }
}