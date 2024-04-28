using System;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class VideoCard : IComponents
{
    public VideoCard(FormFactor size, int amountOfMemory, string versionOfPeripheralComponentI, double chipFrequency, double wattPower, string name)
    {
        if (size is null || !size.CheckOnCorrectInput() || amountOfMemory <= 0 || versionOfPeripheralComponentI is null || versionOfPeripheralComponentI.Length == 0 || chipFrequency <= 0 ||
            wattPower <= 0)
        {
            throw new ArgumentException("Incorrect parameters for VideoCard");
        }

        Size = size;
        AmountOfMemory = amountOfMemory;
        VersionOfPeripheralComponentI = versionOfPeripheralComponentI;
        ChipFrequency = chipFrequency;
        WattPower = wattPower;
        Name = name;
    }

    public FormFactor Size { get; }
    public int AmountOfMemory { get; }
    public string VersionOfPeripheralComponentI { get; }
    public double ChipFrequency { get; }
    public double WattPower { get; }
    public string Name { get; }
}