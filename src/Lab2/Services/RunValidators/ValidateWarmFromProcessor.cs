using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

public class ValidateWarmFromProcessor : IRunValidator
{
    public void CheckPart(Computer computer, IList<string>? problems)
    {
        if (computer != null && computer.Cooler.TDP < computer.Processor.TDP)
        {
            throw new CoolerCantTakeWarmException("Unable to run cus cooler cant take warm from processor");
        }

        if (computer != null && computer.Processor.TDP == computer.Cooler.TDP)
        {
            problems?.Add("Cooler needs max TDP to take warm from processor!");
        }
    }
}