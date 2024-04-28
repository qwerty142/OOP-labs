namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ITreeInteraction
{
    public Folder GetTree(Folder startDir, int depth);
}