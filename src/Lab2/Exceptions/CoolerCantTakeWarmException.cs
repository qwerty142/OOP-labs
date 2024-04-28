using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CoolerCantTakeWarmException : Exception
{
    public CoolerCantTakeWarmException(string message)
        : base(message)
    {
    }

    public CoolerCantTakeWarmException()
    {
    }

    public CoolerCantTakeWarmException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}