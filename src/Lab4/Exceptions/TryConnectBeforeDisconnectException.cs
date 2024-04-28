using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class TryConnectBeforeDisconnectException : Exception
{
    public TryConnectBeforeDisconnectException(string message)
        : base(message)
    {
    }

    public TryConnectBeforeDisconnectException()
    {
    }

    public TryConnectBeforeDisconnectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}