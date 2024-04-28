using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
    protected Deflector(int hp, bool avilabilityOfFoton)
    {
        if (hp < 0)
        {
            throw new ArgumentException("hp should be biger than 0");
        }

        if (avilabilityOfFoton)
        {
            FotonCount += 3;
        }
        else
        {
            FotonCount = 0;
        }

        Hp = hp;
    }

    public int Hp { get; protected set; }
    public int FotonCount { get; protected set; }
    protected int FatalDamage { get; } = -999;
    public abstract void TakeDamage(Obstacle obstacle);
}