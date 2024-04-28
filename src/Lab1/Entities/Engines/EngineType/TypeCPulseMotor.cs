namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;

public class TypeCPulseMotor : Engine
{
    private const int FuelPerDistance = 80;
    public override float CountFuel(int distance)
    {
        int result = distance / FuelPerDistance;
        return result;
    }
}