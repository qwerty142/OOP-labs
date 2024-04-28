namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

public class Meteorits : Obstacle
{
    private const int Damag = 20;
    public Meteorits()
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