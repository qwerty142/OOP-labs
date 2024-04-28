using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class DifferentDDRversionsException : Exception
{
    public DifferentDDRversionsException(string message)
        : base(message)
    {
    }

    public DifferentDDRversionsException()
    {
    }

    public DifferentDDRversionsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}