using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerDetailsRepository;

public interface IDetailsRepository
{
    public Processor GetProcessor(string name);

    public MotherBoard GetMotherBoard(string name);

    public Cooler GetCooler(string name);

    public Storage GetStorage(string name);

    public RandomAccessMemory GetRandomAccessMemory(string name);

    public PowerBlock GetPowerBlock(string name);

    public ComputerCase GetCase(string name);
}