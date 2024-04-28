namespace Itmo.ObjectOrientedProgramming.Lab4;

public class File : IComponent
{
    public File(string name, string shortName)
    {
        Name = name;
        ShortName = shortName;
    }

    public string Name { get; }
    public string ShortName { get; }
}