using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class UnableToPutDetailsInFrameException : Exception
{
    public UnableToPutDetailsInFrameException(string message)
        : base(message)
    {
    }

    public UnableToPutDetailsInFrameException()
    {
    }

    public UnableToPutDetailsInFrameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}