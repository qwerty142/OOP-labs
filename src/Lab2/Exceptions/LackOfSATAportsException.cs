using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class LackOfSATAportsException : Exception
{
    public LackOfSATAportsException(string message)
        : base(message)
    {
    }

    public LackOfSATAportsException()
    {
    }

    public LackOfSATAportsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}