using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

public abstract class Enviroment
{
    protected Enviroment(ICollection<Obstacle> obstacle, int distance)
    {
        if (obstacle is null || !obstacle.Any())
        {
            Obstacles = null;
        }
        else
        {
            Obstacles = obstacle;
        }

        this.Distance = distance;
    }

    public int Distance { get; init; }
    public ICollection<Obstacle>? Obstacles { get; init; }
    public abstract bool CheckShipOnCrossAbility(Engine engine);
}
