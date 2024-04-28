using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateRandomAccessMemory : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null && computer.RandomAccessMemory is not null && computer.Motherboard is not null && computer.Motherboard.RandomAccessMemoryTypes.FirstOrDefault(ddr =>
                ddr.Equals(computer.RandomAccessMemory.RandomAccessMemoryVersion, StringComparison.OrdinalIgnoreCase)) is null)
        {
            throw new DifferentDDRversionsException("Unable to set DDR Memory in mother board");
        }

        return this;
    }
}