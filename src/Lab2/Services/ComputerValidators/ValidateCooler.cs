using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateCooler : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null &&
            computer.Cooler is not null &&
            computer.Processor is not null &&
            computer.Cooler.SupportedSockets.FirstOrDefault(socet =>
                socet.Equals(computer.Processor.Socket, StringComparison.OrdinalIgnoreCase)) is null)
        {
            throw new UnableToPlaceBecauseDifferentSocketException("Unable to put cooler on processor because of different sockets");
        }

        return this;
    }
}