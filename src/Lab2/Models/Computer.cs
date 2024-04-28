using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Computer(
    MotherBoard Motherboard, Processor Processor,
    RandomAccessMemory RandomAccessMemory, Cooler Cooler,
    WiFiModem? WiFiModem,
    IList<Storage> Storage, VideoCard? VideoCard, PowerBlock PowerBlock, ComputerCase ComputerCase,
    IList<IRunValidator> RunValidators)
{
    private List<string>? _securityMessages;
    [SuppressMessage("", "CA2208", Justification = "Иначе не получить имя того что null")]
    public Computer(PartsOfComputer partsOfComputer, IList<IRunValidator> runValidators)
        : this(
            partsOfComputer?.Motherboard ?? throw new ArgumentNullException(nameof(partsOfComputer.Motherboard)),
            partsOfComputer?.Processor ?? throw new ArgumentNullException(nameof(partsOfComputer.Processor)),
            partsOfComputer?.RandomAccessMemory ?? throw new ArgumentNullException(nameof(partsOfComputer.RandomAccessMemory)),
            partsOfComputer?.Cooler ?? throw new ArgumentNullException(nameof(partsOfComputer.Cooler)),
            partsOfComputer?.WiFiModem,
            partsOfComputer?.Storage ?? throw new ArgumentNullException(nameof(partsOfComputer.Storage)),
            partsOfComputer?.VideoCard,
            partsOfComputer?.PowerBlock ?? throw new ArgumentNullException(nameof(partsOfComputer.PowerBlock)),
            partsOfComputer?.ComputerCase ?? throw new ArgumentNullException(nameof(partsOfComputer.ComputerCase)),
            runValidators)
    {
        _securityMessages = new List<string>();
    }

    public IReadOnlyList<string>? ReadList => _securityMessages;

    public bool Run()
    {
        if (Motherboard is null ||
            Processor is null ||
            PowerBlock is null ||
            Cooler is null ||
            RandomAccessMemory is null ||
            Storage is null ||
            ComputerCase is null)
        {
            throw new NoNeedablePartsToRunException("Unable to run cus there is no necessary parts");
        }

        if (RunValidators != null)
        {
            foreach (IRunValidator validator in RunValidators)
            {
                validator.CheckPart(this, _securityMessages);
            }
        }

        return true;
    }
}