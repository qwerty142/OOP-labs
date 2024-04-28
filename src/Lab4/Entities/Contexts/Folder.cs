using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Folder : IComponent
{
    public Folder(string name, string shortName)
    {
        In = new List<IComponent>();
        Name = name;
        ShortName = shortName;
    }

    public string Name { get; }
    public string ShortName { get; }
    public IList<IComponent> In { get; }

    public void AddComponent(IComponent component)
    {
        In.Add(component);
    }
}