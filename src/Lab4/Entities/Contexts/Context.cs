using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Context : IContext
{
    public Context(string path, IFileSystem fileSystem, ITreeInteraction treeInteraction, CreateStringTree createStringTree)
    {
        Path = path;
        FileSystem = fileSystem;
        TreeInteraction = treeInteraction;
        CreateStringTree = createStringTree;
    }

    public string Path { get; set; }
    public IFileSystem FileSystem { get; }
    public ITreeInteraction TreeInteraction { get; }
    public CreateStringTree CreateStringTree { get; }
}