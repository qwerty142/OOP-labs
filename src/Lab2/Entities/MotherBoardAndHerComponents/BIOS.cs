using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;

public class BIOS
{
    public BIOS(string type, string version, IList<Processor> listOfProcessors)
    {
        if (type is null || type.Length < 1 || version is null || version.Length < 1 || !listOfProcessors.Any())
        {
            throw new ArgumentException("Uncorrect parametres for processor");
        }

        Type = type;
        Version = version;
        ListOfSupportedProcessors = listOfProcessors;
    }

    public string Type { get; }
    public string Version { get; }
    public IList<Processor> ListOfSupportedProcessors { get; }
}