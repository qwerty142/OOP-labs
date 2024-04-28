using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoStorageException : Exception
{
    public NoStorageException(string message)
        : base(message)
    {
    }

    public NoStorageException()
    {
    }

    public NoStorageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}