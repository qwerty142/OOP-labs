using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing;
using Itmo.ObjectOrientedProgramming.Lab4.Parsing.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParsersTests
{
    private static IList<ChainLinkBase> _chainLinks = new List<ChainLinkBase>()
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

    private static ChainLinkBase _chainLinkBase = new TreeListHandler();
    static CommandParsersTests()
    {
        for (int i = 1; i < _chainLinks.Count; i++)
        {
            _chainLinks[i].AddNext(_chainLinks[i - 1]);
        }

        _chainLinkBase.AddNext(_chainLinks[_chainLinks.Count - 1]);
    }

    [Fact]
    public void TestParseConnection()
    {
        ICommand? command = _chainLinkBase.Handle("connect C:\\ local");

        Assert.IsType<Connect>(command);
    }

    [Fact]
    public void TestParseDisconnect()
    {
        ICommand? command = _chainLinkBase.Handle("disconnect");

        Assert.IsType<Disconnect>(command);
    }

    [Fact]
    public void TestParseFileCopy()
    {
        ICommand? command = _chainLinkBase.Handle("copy file1 file2");

        Assert.IsType<FileCopy>(command);
    }

    [Fact]
    public void TestParseFileDelete()
    {
        ICommand? command = _chainLinkBase.Handle("delete file");

        Assert.IsType<FileDelete>(command);
    }

    [Fact]
    public void TestParseFileMove()
    {
        ICommand? command = _chainLinkBase.Handle("move file1 file2");

        Assert.IsType<FileMove>(command);
    }

    [Fact]
    public void TestParseFileRename()
    {
        ICommand? command = _chainLinkBase.Handle("rename file name");

        Assert.IsType<FileRename>(command);
    }

    [Fact]
    public void TestParseFileShow()
    {
        ICommand? command = _chainLinkBase.Handle("show file local");

        Assert.IsType<FileShow>(command);
    }

    [Fact]
    public void TestParseTreeGoTo()
    {
        ICommand? command = _chainLinkBase.Handle("treegoto file");

        Assert.IsType<TreeGoTo>(command);
    }

    [Fact]
    public void TestParseTreeList()
    {
        ICommand? command = _chainLinkBase.Handle("treelist 2");

        Assert.IsType<TreeList>(command);
    }

    [Fact]
    public void TestParseIncorrectInput()
    {
        ICommand? command = _chainLinkBase.Handle(" ");

        Assert.Null(command);
    }
}