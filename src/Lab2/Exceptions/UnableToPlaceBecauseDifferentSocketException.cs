using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class UnableToPlaceBecauseDifferentSocketException : Exception
{
    public UnableToPlaceBecauseDifferentSocketException(string message)
        : base(message)
    {
    }

    public UnableToPlaceBecauseDifferentSocketException()
    {
    }

    public UnableToPlaceBecauseDifferentSocketException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}