using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

public class ValidatePresenceOfGraphic : IRunValidator
{
    public void CheckPart(Computer computer, IList<string>? problems)
    {
        if (computer != null && !computer.Processor.IsBuiltInVideoCore && computer.VideoCard is null)
        {
            throw new NogpuException("Unable to run cus no GPU");
        }
    }
}