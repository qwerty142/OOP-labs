using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerDetailsRepository;

public class DetailsRepository : IDetailsRepository
{
    private readonly RepositoryBase<Processor> _processorRepository;
    private readonly RepositoryBase<Cooler> _coolerRepository;
    private readonly RepositoryBase<Storage> _storageRepository;
    private readonly RepositoryBase<ComputerCase> _caseRepository;
    private readonly VideoCardRepository _videoCardRepository;
    private readonly RepositoryBase<MotherBoard> _motherBoardRepository;
    private readonly RepositoryBase<PowerBlock> _powerBlockRepository;
    private readonly RepositoryBase<RandomAccessMemory> _operativeMemoryRepository;
    private readonly WiFiModemRepository _wifiRepository;

    public DetailsRepository(
        RepositoryBase<Processor> processorRepository,
        RepositoryBase<Cooler> coolerRepository,
        RepositoryBase<Storage> storageRepository,
        RepositoryBase<ComputerCase> caseRepository,
        VideoCardRepository videoCardRepository,
        RepositoryBase<MotherBoard> motherBoardRepository,
        RepositoryBase<PowerBlock> powerBlockRepository,
        RepositoryBase<RandomAccessMemory> operativeMemoryRepository,
        WiFiModemRepository wifiRepository)
    {
        ArgumentNullException.ThrowIfNull(processorRepository);
        ArgumentNullException.ThrowIfNull(storageRepository);
        ArgumentNullException.ThrowIfNull(caseRepository);
        ArgumentNullException.ThrowIfNull(coolerRepository);
        ArgumentNullException.ThrowIfNull(videoCardRepository);
        ArgumentNullException.ThrowIfNull(motherBoardRepository);
        ArgumentNullException.ThrowIfNull(powerBlockRepository);
        ArgumentNullException.ThrowIfNull(operativeMemoryRepository);
        ArgumentNullException.ThrowIfNull(wifiRepository);

        _processorRepository = processorRepository;
        _coolerRepository = coolerRepository;
        _storageRepository = storageRepository;
        _caseRepository = caseRepository;
        _videoCardRepository = videoCardRepository;
        _motherBoardRepository = motherBoardRepository;
        _powerBlockRepository = powerBlockRepository;
        _operativeMemoryRepository = operativeMemoryRepository;
        _wifiRepository = wifiRepository;
    }

    public Processor GetProcessor(string name)
    {
        return _processorRepository.GetByName(name);
    }

    public MotherBoard GetMotherBoard(string name)
    {
        return _motherBoardRepository.GetByName(name);
    }

    public Cooler GetCooler(string name)
    {
        return _coolerRepository.GetByName(name);
    }

    public Storage GetStorage(string name)
    {
        return _storageRepository.GetByName(name);
    }

    public RandomAccessMemory GetRandomAccessMemory(string name)
    {
        return _operativeMemoryRepository.GetByName(name);
    }

    public PowerBlock GetPowerBlock(string name)
    {
        return _powerBlockRepository.GetByName(name);
    }

    public ComputerCase GetCase(string name)
    {
        return _caseRepository.GetByName(name);
    }

    public WiFiModem? GetWiFi(string name)
    {
        return _wifiRepository.GetByName(name);
    }

    public VideoCard? GetVideoCard(string name)
    {
        return _videoCardRepository.GetByName(name);
    }
}