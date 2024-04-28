namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;

public class Gamma : JumpEngine
{
    private const float Fuel = 20f;
    public Gamma()
    {
        LargestDistance = 20;
    }

    public override float CountFuel(int distance)
    {
        return distance / Fuel;
    }
}