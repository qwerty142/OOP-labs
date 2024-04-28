namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

public class SpaceWhales : Obstacle
{
    private const int Damag = 200;
    public SpaceWhales()
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