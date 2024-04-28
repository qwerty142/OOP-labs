using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoNeedablePartsToRunException : Exception
{
    public NoNeedablePartsToRunException(string message)
        : base(message)
    {
    }

    public NoNeedablePartsToRunException()
    {
    }

    public NoNeedablePartsToRunException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}