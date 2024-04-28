using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateCase : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null && computer.Motherboard is not null && computer.Cooler is not null &&
            computer.Motherboard.FormFactor.Square +
            computer.Cooler.Dimensions.Square +
            (computer.VideoCard is not null ? computer.VideoCard.Size.Square : 0) >
            computer.ComputerCase.Dimensions.Square)
        {
            throw new UnableToPutDetailsInFrameException("Unable to put all parts in frame");
        }

        return this;
    }
}