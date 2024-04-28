using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerDetailsRepository;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComponentBuilder
{
    private Processor? _processor;
    private Cooler? _coolerSystem;
    private IList<Storage>? _dataStorage;
    private ComputerCase? _case;
    private VideoCard? _video;
    private MotherBoard? _motherBoard;
    private PowerBlock? _power;
    private RandomAccessMemory? _randomAccessMemory;
    private WiFiModem? _wiFiModem;
    private List<string> _securityMessages;

    public ComponentBuilder(DetailsRepository detailsRepository, IList<IComputerValidator> computerValidators, IList<IRunValidator> runValidators)
    {
        _processor = null;
        _coolerSystem = null;
        _dataStorage = null;
        _case = null;
        _video = null;
        _motherBoard = null;
        _power = null;
        _randomAccessMemory = null;
        _securityMessages = new List<string>();
        DetailsRepository = detailsRepository;
        ComputerValidators = computerValidators;
        RunValidators = runValidators;
    }

    public IReadOnlyList<string> ReadList => _securityMessages;
    protected DetailsRepository DetailsRepository { get; }
    protected IList<IComputerValidator> ComputerValidators { get; }
    protected IList<IRunValidator> RunValidators { get; }

    public bool CheckSecurityMessage(string message)
    {
        return _securityMessages.Contains(message);
    }

    public Computer Build()
    {
        return new Computer(Validate(), RunValidators);
    }

    public void WithProcessor(string processorName)
    {
        _processor = DetailsRepository.GetProcessor(processorName);
    }

    public void WithMotherBoard(string motherBoardName)
    {
        _motherBoard = DetailsRepository.GetMotherBoard(motherBoardName);
    }

    public void WithCooler(string coolerName)
    {
        _coolerSystem = DetailsRepository.GetCooler(coolerName);
    }

    public void WithRandomAccessMemory(string randomAccessMemoryName)
    {
        _randomAccessMemory = DetailsRepository.GetRandomAccessMemory(randomAccessMemoryName);
    }

    public void WithStorage(IList<string> storageName)
    {
        _dataStorage = new List<Storage>();
        if (storageName != null)
        {
            foreach (string storage in storageName)
            {
                _dataStorage.Add(DetailsRepository.GetStorage(storage));
            }
        }
    }

    public void WithPowerBlock(string powerBlockName)
    {
        _power = DetailsRepository.GetPowerBlock(powerBlockName);
    }

    public void WithFrame(string frameName)
    {
        _case = DetailsRepository.GetCase(frameName);
    }

    public void WithVideoCard(string videoCardName)
    {
        _video = DetailsRepository.GetVideoCard(videoCardName);
    }

    public void WithWiFi(string wifiName)
    {
        _wiFiModem = DetailsRepository.GetWiFi(wifiName);
    }

    private PartsOfComputer Validate()
    {
        var computer =
            new PartsOfComputer(
                _motherBoard ?? throw new ArgumentNullException(nameof(_motherBoard)),
                _processor ?? throw new ArgumentNullException(nameof(_processor)),
                _randomAccessMemory ?? throw new ArgumentNullException(nameof(_randomAccessMemory)),
                _coolerSystem ?? throw new ArgumentNullException(nameof(_coolerSystem)),
                _wiFiModem,
                _dataStorage ?? throw new ArgumentNullException(nameof(_dataStorage)),
                _video,
                _power ?? throw new ArgumentNullException(nameof(_power)),
                _case ?? throw new ArgumentNullException(nameof(_case)));
        foreach (IComputerValidator validate in ComputerValidators)
        {
            validate.CheckPart(computer);
        }

        return computer;
    }
}