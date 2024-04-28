using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;

public class Augur : Ship
{
    public Augur()
        : base(new ThirdType(false), new TypeEPulseMotor(), new Alpha(), new ThirdTypeOfArmor())
    {
    }
}