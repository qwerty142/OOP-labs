using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

public class ValidateEnoughEnergyToStart : IRunValidator
{
    public void CheckPart(Computer computer, IList<string>? problems)
    {
        double electricityFromDataStorage = 0;
        if (computer != null)
        {
            foreach (Storage storage in computer.Storage)
            {
                electricityFromDataStorage += storage.PowerConsumption;
            }

            double electricity = computer.Processor.PowerConsumption +
                                 electricityFromDataStorage +
                                 (computer.VideoCard is not null ? computer.VideoCard.WattPower : 0) +
                                 (computer.WiFiModem is not null ? computer.WiFiModem.PowerConsumption : 0);
            if (electricity > computer.PowerBlock.PeakLoad)
            {
                throw new LackOfEnergyFromPBException("Unable to run cus PB cant run");
            }

            if (electricity == computer.PowerBlock.PeakLoad)
            {
                problems?.Add("PB needs peek load to run system!");
            }
        }
    }
}