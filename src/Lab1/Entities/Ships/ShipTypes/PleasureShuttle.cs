using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;

public class PleasureShuttle : Ship
{
    public PleasureShuttle()
        : base(null, new TypeCPulseMotor(), null, new FirstTypeOfArmor())
    {
    }
}