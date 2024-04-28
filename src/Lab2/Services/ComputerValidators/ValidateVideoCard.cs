using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore.StorageTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;

public class ValidateVideoCard : IComputerValidator
{
    public IComputerValidator CheckPart(PartsOfComputer computer)
    {
        if (computer != null && computer.VideoCard is null)
        {
            return this;
        }
        else
        {
            // Тут идет то что приоритет идет на Видеокарту + хотя бы 1 хранилище
            if (computer != null &&
                computer.Storage.Any(storage => storage is SSD) &&
                !computer.Processor.IsBuiltInVideoCore &&
                computer.Motherboard.PeripheralComponentStrings <= 1)
            {
                throw new LackOfPCIstringsException("Unable to run because only 1 PCI string for SSD and video card");
            }
        }

        return this;
    }
}