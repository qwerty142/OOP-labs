namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;

public class TypeEPulseMotor : Engine
{
    private const int FuelPerDistance = 100;
    public override float CountFuel(int distance)
    {
        int result = distance / FuelPerDistance;
        return result;
    }
}