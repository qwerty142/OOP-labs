using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;
using Itmo.ObjectOrientedProgramming.Lab4.ConsoleWriters;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Systems;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class RuningProgramm
{
    public static void Main()
    {
        IConsoleWriter writer = new WindowsConsoleWriter();
        var chain = new TreeListHandler();
        IList<ChainLinkBase> chainLinks = new List<ChainLinkBase>()
        {
            new ConnectHandler(),
            new DisconnectHandler(),
            new FileCopyHandler(),
            new FileDeleteHandler(),
            new FileMoveHandler(),
            new FileRenameHandler(),
            new FileShowHandler(),
            new TreeGoToHandler(),
        };

        for (int i = 1; i < chainLinks.Count; i++)
        {
            chainLinks[i].AddNext(chainLinks[i - 1]);
        }

        chain.AddNext(chainLinks[chainLinks.Count - 1]);
        ICommand? command = null;
        IContext context = new Context(
            string.Empty,
            new StandardFileSystem(),
            new TreeInteraction(),
            new CreateStringTree("#", "*", ' '));
        writer.Write("Possible commands:\nconnect\ndisconnect\ncopy\ndelete\nmove\nrename\nshow\ntreegoto\ntreelist");
        while (command is not Disconnect)
        {
            string? message = writer.GetMessage();
            if (message is not null)
            {
                command = chain.Handle(message);
                writer.Write(command?.Run(context));
            }
        }
    }
}