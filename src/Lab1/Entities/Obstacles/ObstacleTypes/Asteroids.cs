namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

public class Asteroids : Obstacle
{
    private const int Damag = 10;
    public Asteroids()
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