namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class FileDelete : ICommand
{
    private string _path;

    public FileDelete(string path)
    {
        _path = path;
    }

    public string Run(IContext currentFile)
    {
        currentFile?.FileSystem.FileDelete(_path);
        return "Success";
    }
}