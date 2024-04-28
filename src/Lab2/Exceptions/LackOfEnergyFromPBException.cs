using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class LackOfEnergyFromPBException : Exception
{
    public LackOfEnergyFromPBException(string message)
        : base(message)
    {
    }

    public LackOfEnergyFromPBException()
    {
    }

    public LackOfEnergyFromPBException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}