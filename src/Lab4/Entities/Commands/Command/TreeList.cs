using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class TreeList : ICommand
{
    private int _depth;

    public TreeList(int depth)
    {
        _depth = depth;
    }

    public string Run(IContext currentFile)
    {
        if (currentFile is null)
        {
            throw new ArgumentNullException(nameof(currentFile));
        }

        var fold = new Folder(
            currentFile.Path,
            currentFile.
                Path.
                Substring(currentFile.Path.LastIndexOf('/') + 1));
        currentFile.TreeInteraction.GetTree(fold, _depth);
        return currentFile.CreateStringTree.CreateTree(fold, string.Empty, 0);
    }
}