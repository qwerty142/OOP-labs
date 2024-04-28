using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IContext
{
    public string Path { get; set; }
    public IFileSystem FileSystem { get; }
    public ITreeInteraction TreeInteraction { get; }
    public CreateStringTree CreateStringTree { get; }
}