using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;

public class Vaklas : Ship
{
    public Vaklas()
        : base(new FirstType(false), new TypeEPulseMotor(), new Gamma(), new SecondTypeOfArmor())
    {
    }
}