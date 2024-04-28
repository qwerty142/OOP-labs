using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public interface IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer);
}