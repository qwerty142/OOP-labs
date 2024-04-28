using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;

public class ComputerCase : IComponents
{
    public ComputerCase(MaximumLengthAndWidthOfVideoCard maxLengthAndHeight, IList<FormFactor> availableFormFactor, FormFactor dimensions, string name)
    {
        if (maxLengthAndHeight is null || !maxLengthAndHeight.CheckCorrectData() || !availableFormFactor.Any() ||
            dimensions is null || !dimensions.CheckOnCorrectInput())
        {
            throw new ArgumentException("Uncorrect parametres for ComputerCase");
        }

        MaxLengthAndHeight = maxLengthAndHeight;
        AvailableFormFactor = availableFormFactor;
        Dimensions = dimensions;
        Name = name;
    }

    public MaximumLengthAndWidthOfVideoCard MaxLengthAndHeight { get; }
    public IList<FormFactor> AvailableFormFactor { get; }
    public FormFactor Dimensions { get; }
    public string Name { get; }
}