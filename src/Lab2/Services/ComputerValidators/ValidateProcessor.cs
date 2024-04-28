using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateProcessor : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null && computer.Motherboard is not null && computer.Processor is not null && (computer.Motherboard.Socket != computer.Processor.Socket ||
                computer.Motherboard.Bios.ListOfSupportedProcessors.FirstOrDefault(cpu =>
                    cpu.Name.Equals(computer.Processor.Name, StringComparison.OrdinalIgnoreCase)) is null))
        {
            throw new UnableToPlaceBecauseDifferentSocketException("Unable to put processor on mother board");
        }

        return this;
    }
}