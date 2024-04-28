using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoPowerUnitException : Exception
{
    public NoPowerUnitException(string message)
        : base(message)
    {
    }

    public NoPowerUnitException()
    {
    }

    public NoPowerUnitException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}