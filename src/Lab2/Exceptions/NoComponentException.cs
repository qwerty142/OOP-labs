using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoComponentException : Exception
{
    public NoComponentException(string message)
        : base(message)
    {
    }

    public NoComponentException()
    {
    }

    public NoComponentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}