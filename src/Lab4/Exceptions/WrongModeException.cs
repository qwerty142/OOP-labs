using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class WrongModeException : Exception
{
    public WrongModeException(string message)
        : base(message)
    {
    }

    public WrongModeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WrongModeException()
    {
    }
}