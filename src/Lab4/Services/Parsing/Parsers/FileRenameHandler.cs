using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class FileRenameHandler : ChainLinkBase
{
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);

        string[] options = command.Split(' ');

        if (options[0] == "rename" && options.Length == 3)
        {
            return new FileRename(options[1], options[2]);
        }

        return ParseNext(command);
    }
}