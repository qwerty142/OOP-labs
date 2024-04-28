using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;

public class Meridian : Ship
{
    public Meridian()
        : base(new SecondType(false), new TypeEPulseMotor(), null, new SecondTypeOfArmor())
    {
    }
}