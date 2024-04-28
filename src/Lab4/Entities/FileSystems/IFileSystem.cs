namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public bool Connect(string path);
    public string Disconnect();
    public bool FileCopy(string start, string destination);
    public bool FileDelete(string path);
    public bool FileMove(string start, string destination);
    public bool FileRename(string path, string name);
    public string FileShow(string path);
    public void ChangePath(string newPath, IContext context);
}