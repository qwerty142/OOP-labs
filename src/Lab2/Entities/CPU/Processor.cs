using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

public class Processor : IComponents
{
    public Processor(int coreFrequency, int amountOfCore, string socket, bool isBuiltInVideoCore, IList<int> memoryFrequencies, int tdp, int powerConsumption, string name)
    {
        if (coreFrequency <= 0 || amountOfCore <= 0 || socket is null || socket.Length == 0 || !memoryFrequencies.Any() || tdp <= 0 ||
            powerConsumption <= 0)
        {
            throw new ArgumentException("Uncorrected parameters for processor");
        }

        CoreFrequency = coreFrequency;
        AmountOfCore = amountOfCore;
        Socket = socket;
        IsBuiltInVideoCore = isBuiltInVideoCore;
        SupportedMemoryFrequencies = memoryFrequencies;
        TDP = tdp;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int CoreFrequency { get; }
    public int AmountOfCore { get; }
    public string Socket { get; }
    public bool IsBuiltInVideoCore { get; }
    public IList<int> SupportedMemoryFrequencies { get; }
    public int TDP { get; }
    public int PowerConsumption { get; }
    public string Name { get; }
}