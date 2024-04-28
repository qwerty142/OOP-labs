namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

public class AntimatterFlares : Obstacle
{
    private const int Damag = 1;
    public AntimatterFlares()
        : base(Damag)
    {
    }

    public override void Reset()
    {
        DamageValue = Damag;
    }

    public override void Damage(int damage)
    {
        DamageValue -= damage;
    }
}