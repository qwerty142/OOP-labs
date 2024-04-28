using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments.EnvTypes;

public class NormalSpace : Enviroment
{
    public NormalSpace(ICollection<Obstacle> obstacle, int distance)
        : base(obstacle, distance)
    {
    }

    public override bool CheckShipOnCrossAbility(Engine engine)
    {
        if (engine is not null)
        {
            return true;
        }

        return false;
    }
}