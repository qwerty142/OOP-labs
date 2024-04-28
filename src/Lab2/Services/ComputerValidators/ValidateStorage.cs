using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateStorage : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null && (computer.Storage is null || computer.Motherboard is null))
        {
            throw new NoStorageException("No needed parts");
        }

        if (computer != null)
        {
            int sataPorts = computer.Motherboard.SataPorts;
            int pciStrings = computer.Motherboard.PeripheralComponentStrings;

            foreach (Storage storage in computer.Storage)
            {
                if (storage.ConnectionType == "SATA")
                {
                    sataPorts -= 1;
                    if (sataPorts < 0)
                    {
                        throw new LackOfSATAportsException("Unable to build because there is no needed SATA ports");
                    }
                }

                if (storage.ConnectionType == "PCI")
                {
                    pciStrings -= 1;
                    if (pciStrings < 0)
                    {
                        throw new LackOfPCIstringsException("Unable to build because there is no needed PCI strings");
                    }
                }
            }
        }

        return this;
    }
}