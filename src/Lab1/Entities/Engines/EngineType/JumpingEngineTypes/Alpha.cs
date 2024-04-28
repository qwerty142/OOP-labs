namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;

public class Alpha : JumpEngine
{
    private const float Fuel = 10f;

    public Alpha()
    {
        LargestDistance = 10;
    }

    public override float CountFuel(int distance)
    {
        return distance / Fuel;
    }
}