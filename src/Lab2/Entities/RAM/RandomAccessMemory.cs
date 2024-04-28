using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RandomAccessMemory : IComponents
{
    public RandomAccessMemory(int maxMemory, IList<FrequencyAndVoltage> availableFrequencyAndVoltage, IList<XMP> availableXmp, FormFactor formFactor, string ddrVersion, double powerConsumption, string name)
    {
        if (maxMemory <= 0 || !availableFrequencyAndVoltage.Any() || !availableXmp.Any() || formFactor is null ||
            formFactor.Height <= 0 || formFactor.Width <= 0 || ddrVersion is null || ddrVersion.Length == 0 || powerConsumption <= 0)
        {
            throw new ArgumentException("Incorrect parameters for RAM");
        }

        MaxMemory = maxMemory;
        AvailableFrequencyAndVoltage = availableFrequencyAndVoltage;
        AvailableXmp = availableXmp;
        FormFactor = formFactor;
        RandomAccessMemoryVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int MaxMemory { get; }
    public IList<FrequencyAndVoltage> AvailableFrequencyAndVoltage { get; }
    public IList<XMP> AvailableXmp { get; }
    public FormFactor FormFactor { get; }
    public string RandomAccessMemoryVersion { get; }
    public double PowerConsumption { get; }
    public string Name { get; }
}