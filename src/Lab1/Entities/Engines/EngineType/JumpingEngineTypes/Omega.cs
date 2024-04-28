namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;

public class Omega : JumpEngine
{
    private const float Fuel = 30f;
    public Omega()
    {
        LargestDistance = 30;
    }

    public override float CountFuel(int distance)
    {
        return distance / Fuel;
    }
}