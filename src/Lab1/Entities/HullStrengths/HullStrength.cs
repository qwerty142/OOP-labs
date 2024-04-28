using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths;

public abstract class HullStrength
{
    public int FatalDamage { get; } = -999;
    protected int Hp { get; set; }
    public abstract void TakeDamage(Obstacle obstacle, Deflector deflector);
}