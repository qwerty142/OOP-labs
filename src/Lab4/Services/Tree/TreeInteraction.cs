namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeInteraction : ITreeInteraction
{
    public Folder GetTree(Folder startDir, int depth)
    {
        ITreeVisitor treeVisitor = new TreeVisitor();

        treeVisitor.VisitFolder(startDir, depth);
        return startDir;
    }
}