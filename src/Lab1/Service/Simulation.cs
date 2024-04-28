using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments.EnvTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Roots;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class Simulation
{
    private List<Ship> shipers;
    private Way _way;

    public Simulation(Way way, ICollection<Ship> ships)
    {
        _way = way;
        shipers = ships.ToList();
        ResultsList = new List<Results>();
    }

    public IList<Results> ResultsList { get; }
    public void CheckShips()
    {
        if (shipers is null || !shipers.Any())
        {
            throw new ArgumentNullException(nameof(shipers));
        }

        foreach (Ship ship in shipers)
        {
            var currentResults = new Results();
            currentResults.CurrentShip = ship;
            foreach (Segment seg in _way.Segment)
            {
                currentResults = CheckEngine(ship, seg, currentResults);
                if (currentResults.CurStatus == Results.TeamStatus.Lost)
                {
                    ResultsList.Add(currentResults);
                    break;
                }

                currentResults = CheckOnObstacles(ship, seg, currentResults);
                if (currentResults.CurStatus != Results.TeamStatus.Alive)
                {
                    ResultsList.Add(currentResults);
                    break;
                }

                currentResults = CountFuelOnShip(ship, seg, currentResults);
                if (currentResults.CurStatus != Results.TeamStatus.Alive)
                {
                    ResultsList.Add(currentResults);
                    break;
                }
            }

            if (currentResults.CurStatus == Results.TeamStatus.Alive)
            {
                ResultsList.Add(currentResults);
            }
        }
    }

    public Ship? MostEffectiveShip()
    {
        // Nullable так как могло быть что никто не выжил
        Results? mostEffectiveShip = ResultsList.Where(result => result.CurStatus == Results.TeamStatus.Alive).MinBy(result => result.AmountOfFuel);
        if (mostEffectiveShip is null)
        {
            return null;
        }

        return mostEffectiveShip.CurrentShip;
    }

    public void UpdateStatus()
    {
        foreach (Results results in ResultsList)
        {
            if (results.CurStatus != Results.TeamStatus.Alive)
            {
                results.CurrentShip.ReNewStatus(false);
            }
            else
            {
                results.CurrentShip.ReNewStatus(true);
            }
        }
    }
#pragma warning disable CA1822
    private Results CheckEngine(Ship ship, Segment segment, Results result)
    {
        if (ship.Engine != null)
        {
            if (segment.Enviroment is NebulaeOfIncreasedDensityOfSpace)
            {
                if (ship.JumpEngine is null || segment.Enviroment.CheckShipOnCrossAbility(ship.JumpEngine) is false)
                {
                    result.CurStatus = Results.TeamStatus.Lost;
                    return result;
                }
            }
            else
            {
                if (segment.Enviroment.CheckShipOnCrossAbility(ship.Engine) is false)
                {
                    result.CurStatus = Results.TeamStatus.Lost;
                    return result;
                }
            }
        }

        return result;
    }

    private Results CheckOnObstacles(Ship ship, Segment segment, Results result)
    {
        if (segment.Enviroment.Obstacles is not null)
        {
            foreach (Obstacle obstacle in segment.Enviroment.Obstacles)
            {
                ship.TakeDamage(obstacle);
                if (!ship.IsAlive)
                {
                    result.CurStatus = Results.TeamStatus.TeamDead;
                    obstacle.Reset();
                    return result;
                }

                obstacle.Reset();
            }
        }

        return result;
    }

    private Results CountFuelOnShip(Ship ship, Segment segment, Results results)
    {
        if (segment.Enviroment is NebulaeOfIncreasedDensityOfSpace obj)
        {
            if (ship.JumpEngine != null)
            {
                results.AmountOfFuel += ship.JumpEngine.CountFuel(obj.Distance);
            }
            else
            {
                results.CurStatus = Results.TeamStatus.Lost;
                return results;
            }
        }

        if (ship.Engine != null) results.AmountOfFuel += ship.Engine.CountFuel(segment.Enviroment.Distance);
        return results;
    }
}