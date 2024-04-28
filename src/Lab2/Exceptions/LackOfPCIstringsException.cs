using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class LackOfPCIstringsException : Exception
{
    public LackOfPCIstringsException(string message)
        : base(message)
    {
    }

    public LackOfPCIstringsException()
    {
    }

    public LackOfPCIstringsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}