using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoProcessorException : Exception
{
    public NoProcessorException(string message)
        : base(message)
    {
    }

    public NoProcessorException()
    {
    }

    public NoProcessorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}