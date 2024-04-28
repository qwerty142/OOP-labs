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

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record PartsOfComputer(MotherBoard Motherboard, Processor Processor,
    RandomAccessMemory RandomAccessMemory, Cooler Cooler,
    WiFiModem? WiFiModem,
    IList<Storage> Storage, VideoCard? VideoCard, PowerBlock PowerBlock, ComputerCase ComputerCase);