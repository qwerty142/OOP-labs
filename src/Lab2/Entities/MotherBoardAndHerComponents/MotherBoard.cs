using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;

public class MotherBoard : IComponents
{
    public MotherBoard(string socket, int pciStrings, int sataPorts, bool isXmp, IList<int> memoryFrequency, IList<string> ddrTypes, int slotForMemory, FormFactor formFactor, BIOS bios, string name)
    {
        if (socket is null || socket.Length == 0 || sataPorts < 0 || pciStrings < 0 || !memoryFrequency.Any() ||
            !ddrTypes.Any() || slotForMemory <= 0 || formFactor is null || formFactor.Height <= 0 || formFactor.Width <= 0 || bios is null)
        {
            throw new ArgumentException("Uncorrected arguments for MotherBoard");
        }

        Socket = socket;
        PeripheralComponentStrings = pciStrings;
        SataPorts = sataPorts;
        IsXMP = isXmp;
        MemoryFrequency = memoryFrequency;
        RandomAccessMemoryTypes = ddrTypes;
        SlotForMemory = slotForMemory;
        FormFactor = formFactor;
        Bios = bios;
        Name = name;
    }

    public string Socket { get; }
    public int PeripheralComponentStrings { get; }
    public int SataPorts { get; }
    public bool IsXMP { get; }
    public IList<int> MemoryFrequency { get; }
    public IList<string> RandomAccessMemoryTypes { get; }
    public int SlotForMemory { get; }
    public FormFactor FormFactor { get; }
    public string Name { get; }
    public BIOS Bios { get; }
}