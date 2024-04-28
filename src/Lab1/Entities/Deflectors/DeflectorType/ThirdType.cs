using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors.DeflectorType;

public class ThirdType : Deflector
{
    private const int HealthPoints = 400;
    public ThirdType(bool aviableFoton)
        : base(HealthPoints, aviableFoton)
    {
    }

    public override void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is not null)
        {
            if (obstacle is AntimatterFlares)
            {
                if (FotonCount <= 0)
                {
                    obstacle.Damage(FatalDamage);
                }
                else
                {
                    FotonCount -= obstacle.DamageValue;
                    obstacle.Damage(obstacle.DamageValue);
                }
            }
            else
            {
                int actual = obstacle.DamageValue < Hp ? obstacle.DamageValue : Hp;
                Hp -= actual;
                obstacle.Damage(actual);
            }
        }
        else
        {
            throw new ArgumentException("Uncorrect obstacle : ", nameof(obstacle));
        }
    }
}