namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Command;

public class FileCopy : ICommand
{
    private string _source;
    private string _destination;

    public FileCopy(string source, string destination)
    {
        _source = source;
        _destination = destination;
    }

    public string Run(IContext currentFile)
    {
        currentFile?.FileSystem.FileCopy(_source, _destination);
        return "Success";
    }
}