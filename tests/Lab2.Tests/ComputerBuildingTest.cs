using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore.StorageTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerDetailsRepository;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidators;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RunValidators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuildingTest
{
    private ProcessorRepository _processorRepository = new ProcessorRepository(new Collection<Processor>()
        { new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 10, 2, "AMD3") });

    private MotherBoardRepository _motherBoardRepository = new MotherBoardRepository(new Collection<Entities.MotherBoardAndHerComponents.MotherBoard>()
    {
        new MotherBoard(
            "AM4",
            6,
            6,
            true,
            new List<int>() { 123, 456, 434 },
            new List<string>() { "DDR4", "DDR5" },
            2,
            new FormFactor(3, 4),
            new BIOS("GH", "first", new List<Processor>() { new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 10, 2, "AMD3"), new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 1000, 2, "Intel5"), new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 10, 1000000, "Intel1") }),
            "Asrock"),
    });

    private CoolerRepository _coolerRepository = new CoolerRepository(new Collection<Cooler>()
        { new Cooler(new FormFactor(2, 2), new List<string>() { "AM4" }, 2000, "fgh") });

    private RandomAccessMemoryRepository _randomAccessMemoryRepository = new RandomAccessMemoryRepository(
        new Collection<RandomAccessMemory>()
        {
            new RandomAccessMemory(
                16,
                new List<FrequencyAndVoltage>() { new FrequencyAndVoltage(123, 456) },
                new List<XMP>() { new XMP("12", new FrequencyAndVoltage(123, 456)) },
                new FormFactor(2, 4),
                "DDR4",
                12,
                "ryzen"),
        });

    private StorageRepository _storageRepository =
        new StorageRepository(new Collection<Storage>() { new SSD(256, 1200, 12, "ghjk", "PCI") });

    private PowerBlockRepository _powerBlockRepository =
        new PowerBlockRepository(new Collection<PowerBlock>() { new PowerBlock(800, "abacaba") });

    private VideoCardRepository _videoCardRepository = new VideoCardRepository(new Collection<VideoCard>());
    private WiFiModemRepository _wiFiModemRepository = new WiFiModemRepository(new Collection<WiFiModem>());

    private CaseRepository _caseRepository = new CaseRepository(new Collection<ComputerCase>()
    {
        new ComputerCase(
            new MaximumLengthAndWidthOfVideoCard(400, 500),
            new List<FormFactor>() { new FormFactor(800, 2000) },
            new FormFactor(7000, 7000),
            "hjkl"),
    });

    private IList<IComputerValidator> computerValidator = new Collection<IComputerValidator>()
    {
        new ValidateCooler(), new ValidateCase(), new ValidateProcessor(), new ValidateStorage(),
        new ValidateRandomAccessMemory(), new ValidatePowerUnit(), new ValidateVideoCard(), new ValidateWiFiModem(),
    };

    private IList<IRunValidator> runValidators = new Collection<IRunValidator>()
    {
        new ValidatePresenceOfGraphic(), new ValidateWarmFromProcessor(), new ValidateEnoughEnergyToStart(),
    };
    [Fact]
    public void GuaranteedWorkingAssemblyWithoutWarnings()
    {
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("fgh");
        componentBuilder.WithProcessor("AMD3");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("abacaba");
        componentBuilder.WithMotherBoard("Asrock");
        Computer computer = componentBuilder.Build();

        Assert.NotNull(computer);
        Assert.True(computer.Run());
        if (computer.ReadList != null) Assert.Empty(computer.ReadList);
    }

    [Fact]
    public void BuildingWorkingComputerWithBorderlineEnergyConsumption()
    {
        // Peak load whith current parts = 2 + 12 = 14
        _powerBlockRepository.Add(new PowerBlock(14, "pwoerBlockWithPeakLoad14"));
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("fgh");
        componentBuilder.WithProcessor("AMD3");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("pwoerBlockWithPeakLoad14");
        componentBuilder.WithMotherBoard("Asrock");
        Computer computer = componentBuilder.Build();

        Assert.NotNull(computer);
        Assert.True(computer.Run());
        if (computer.ReadList != null)
            Assert.Contains("PB needs peek load to run system!", computer.ReadList);
    }

    [Fact]
    public void BuildingWorkingComputerButCoolerNeedsPeakHeatAbsorption()
    {
        // Peak heat absorption = 10
        _coolerRepository.Add(new Cooler(new FormFactor(2, 2), new List<string>() { "AM4" }, 10, "PeakHeatAbsorption10"));
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("PeakHeatAbsorption10");
        componentBuilder.WithProcessor("AMD3");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("abacaba");
        componentBuilder.WithMotherBoard("Asrock");
        Computer computer = componentBuilder.Build();

        Assert.NotNull(computer);
        Assert.True(computer.Run());
        if (computer.ReadList != null)
            Assert.Contains("Cooler needs max TDP to take warm from processor!", computer.ReadList);
    }

    [Fact]
    public void BuildComputerWithDifferentSocketOfMotherBoardAndProcessor()
    {
        // Mother board socet is AM4 and processor socet is AM3
        _processorRepository.Add(new Processor(
            1,
            1,
            "AM3",
            true,
            new List<int>() { 123, 456, 434 },
            10,
            2,
            "AMD1"));
        _coolerRepository.Add(new Cooler(new FormFactor(1, 1), new List<string>() { "AM3" }, 30, "coolerForAM3"));
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("coolerForAM3");
        componentBuilder.WithProcessor("AMD1");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("abacaba");
        componentBuilder.WithMotherBoard("Asrock");

        Assert.Throws<UnableToPlaceBecauseDifferentSocketException>(() => componentBuilder.Build());
    }

    [Fact]
    public void CorrectlyAssembledComputerButImpossibleToRunOfProcessorWarm()
    {
        // TDP of processor is 1000000
        _processorRepository.Add(new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 1000000, 2, "Intel5"));
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("fgh");
        componentBuilder.WithProcessor("Intel5");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("abacaba");
        componentBuilder.WithMotherBoard("Asrock");
        Computer computer = componentBuilder.Build();

        Assert.Throws<CoolerCantTakeWarmException>(() => computer.Run());
    }

    [Fact]
    public void CorrectlyAssembledComputerButImpossibleToRunOfLackEnergy()
    {
        // power consumption 1000000
        _processorRepository.Add(new Processor(1, 1, "AM4", true, new List<int>() { 123, 456, 434 }, 10, 1000000, "Intel1"));
        var detailsRepository = new DetailsRepository(
            _processorRepository,
            _coolerRepository,
            _storageRepository,
            _caseRepository,
            _videoCardRepository,
            _motherBoardRepository,
            _powerBlockRepository,
            _randomAccessMemoryRepository,
            _wiFiModemRepository);

        var componentBuilder = new ComponentBuilder(detailsRepository, computerValidator, runValidators);
        componentBuilder.WithCooler("fgh");
        componentBuilder.WithProcessor("Intel1");
        componentBuilder.WithRandomAccessMemory("ryzen");
        componentBuilder.WithFrame("hjkl");
        componentBuilder.WithStorage(new List<string>() { "ghjk" });
        componentBuilder.WithPowerBlock("abacaba");
        componentBuilder.WithMotherBoard("Asrock");
        Computer computer = componentBuilder.Build();

        Assert.Throws<LackOfEnergyFromPBException>(() => computer.Run());
    }
}