using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotExistingPathException : Exception
{
    public NotExistingPathException(string message)
        : base(message)
    {
    }

    public NotExistingPathException()
    {
    }

    public NotExistingPathException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}