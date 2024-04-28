using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NogpuException : Exception
{
    public NogpuException(string message)
        : base(message)
    {
    }

    public NogpuException()
    {
    }

    public NogpuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}