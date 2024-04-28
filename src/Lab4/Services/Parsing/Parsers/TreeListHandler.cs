using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class TreeListHandler : ChainLinkBase
{
    [SuppressMessage("", "CA1305", Justification = "d")]
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);

        string[] options = command.Split(' ');

        if (options[0] == "treelist" && options.Length == 2)
        {
            return new TreeList(System.Convert.ToInt32(options[1]));
        }

        return ParseNext(command);
    }
}