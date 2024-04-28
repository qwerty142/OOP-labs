namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ITreeVisitor
{
    public void VisitFolder(Folder folder, int depth);
    public void VisitFile(File file, Folder currentFolder);
}