using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments.EnvTypes;

public class NitrineParticleNebulae : Enviroment
{
    public NitrineParticleNebulae(ICollection<Obstacle> obstacle, int distance)
        : base(obstacle, distance)
    {
    }

    public override bool CheckShipOnCrossAbility(Engine engine)
    {
        if (engine is not null)
        {
            if (engine is TypeEPulseMotor)
            {
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