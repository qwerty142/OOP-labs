using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

public interface IRunValidator
{
    public void CheckPart(Computer computer, IList<string>? problems);
}