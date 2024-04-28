using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments.EnvTypes;

public class NebulaeOfIncreasedDensityOfSpace : Enviroment
{
    public NebulaeOfIncreasedDensityOfSpace(ICollection<Obstacle> obstaclesCollection, int distance)
        : base(obstaclesCollection, distance)
    {
    }

    public override bool CheckShipOnCrossAbility(Engine engine)
    {
        if (engine is not null)
        {
            if (engine is JumpEngine curEngine)
            {
                if (this.Distance <= curEngine.LargestDistance)
                    return true;
            }

            return false;
        }
        else
        {
            throw new ArgumentException("no engine");
        }
    }
}