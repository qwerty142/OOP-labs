using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

public class DisconnectHandler : ChainLinkBase
{
    public override ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command == "disconnect")
        {
            return new Disconnect();
        }

        return ParseNext(command);
    }
}