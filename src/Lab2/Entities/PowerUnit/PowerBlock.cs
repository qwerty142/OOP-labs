using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

public class PowerBlock : IComponents
{
    public PowerBlock(double peakLoad, string name)
    {
        if (peakLoad <= 0)
        {
            throw new ArgumentException("Incorrect parameters for PowerBlock");
        }

        PeakLoad = peakLoad;
        Name = name;
    }

    public double PeakLoad { get; }
    public string Name { get; }
}