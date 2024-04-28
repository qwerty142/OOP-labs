namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(int damageValue)
    {
        this.DamageValue = damageValue;
    }

    public int DamageValue { get; protected set; }
    public abstract void Reset();
    public abstract void Damage(int damage);
}