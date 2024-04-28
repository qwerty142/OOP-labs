using System;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class XMP
{
    public XMP(string timing, FrequencyAndVoltage frequencyAndVoltage)
    {
        if (timing is null || timing.Length == 0 || frequencyAndVoltage is null || frequencyAndVoltage.Frequncy <= 0 || frequencyAndVoltage.Voltage <= 0)
        {
            throw new ArgumentException("Incorrect parameters for XMP");
        }

        Timing = timing;
        FrequencyAndVoltage = frequencyAndVoltage;
    }

    public string Timing { get; }
    private FrequencyAndVoltage FrequencyAndVoltage { get; }
}