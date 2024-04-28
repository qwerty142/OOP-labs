using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class Cooler : IComponents
{
    public Cooler(FormFactor dimensions, IList<string> supportedSockets, int tdp, string name)
    {
        if (dimensions is null || dimensions.Height <= 0 || dimensions.Width <= 0 || !supportedSockets.Any() || tdp < 0)
        {
            throw new ArgumentException("Uncorrected input parameters for CoolingSystem");
        }

        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        TDP = tdp;
        Name = name;
    }

    public FormFactor Dimensions { get; }
    public IList<string> SupportedSockets { get; }
    public int TDP { get; }
    public string Name { get; }
}