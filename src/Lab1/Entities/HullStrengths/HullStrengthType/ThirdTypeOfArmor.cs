using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;

public class ThirdTypeOfArmor : HullStrength
{
    public ThirdTypeOfArmor()
    {
        this.Hp = 200;
    }

    public override void TakeDamage(Obstacle obstacle, Deflector deflector)
    {
        if (deflector is null)
        {
            throw new ArgumentNullException(nameof(deflector));
        }

        if (obstacle is not null)
        {
            if (obstacle is AntimatterFlares && deflector.FotonCount <= 0)
            {
                obstacle.Damage(FatalDamage);
            }
            else
            {
                int actual = obstacle.DamageValue < this.Hp ? obstacle.DamageValue : this.Hp;
                this.Hp -= actual;
                obstacle.Damage(actual);
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(obstacle));
        }
    }
}