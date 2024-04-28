using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType.JumpingEngineTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments.EnvTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths.HullStrengthType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles.ObstacleTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Roots;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test1
{
    [Fact]
    public void Mediumlengthrouteinanebulaofhighspatialdensity()
    {
        // Medium-length route in a nebula of high spatial density + Augur + Pleasure shuttle
        Ship firstShip = new Augur(); // dead
        Ship secondShip = new PleasureShuttle(); // dead
        var cursegment = new Segment(new NebulaeOfIncreasedDensityOfSpace(new List<Obstacle>(), 20));
        ICollection<Segment> currentway = new List<Segment>();
        currentway.Add(cursegment);
        var currentShips = new List<Ship>();
        currentShips.Add(firstShip);
        currentShips.Add(secondShip);
        var way = new Way(currentway);
        var simulation = new Simulation(way, currentShips);
        simulation.CheckShips();
        simulation.UpdateStatus();

        // Asert
        Assert.False(firstShip.IsAlive);
        Assert.False(secondShip.IsAlive);
    }

    [Fact]
    public void Antimatterflashinasubspacechannel()
    {
        // Antimatter flash in a subspace channel + Vaklas + Vaklas with Foton deflector
        Ship firstShip = new Vaklas(); // teamdead
        var secondShip = new Ship(new FirstType(true), new TypeEPulseMotor(), new Gamma(), new SecondTypeOfArmor());

        // alive
        var obstacles = new List<Obstacle>();
        obstacles.Add(new AntimatterFlares());
        ICollection<Segment> currentway = new List<Segment>();
        var cursegment = new Segment(new NebulaeOfIncreasedDensityOfSpace(obstacles, 10));
        currentway.Add(cursegment);
        var currentShips = new List<Ship>();
        currentShips.Add(firstShip);
        currentShips.Add(secondShip);
        var way = new Way(currentway);
        var simulation = new Simulation(way, currentShips);
        simulation.CheckShips();
        simulation.UpdateStatus();

        // Assert
        Assert.Equal(Results.TeamStatus.TeamDead, simulation.ResultsList[0].CurStatus);
        Assert.True(secondShip.IsAlive);
    }

    [Fact]
    public void SpacewhaleintheNitrineParticleNebula()
    {
        // Space whale in the Nitrine Particle Nebula + Valkas + Augur + Meredian
        Ship firstShip = new Vaklas(); // dead
        Ship secondShip = new Augur(); // alive
        Ship thirdShip = new Meridian(); // alive
        Obstacle obstacle = new SpaceWhales();
        var curObstacles = new List<Obstacle>();
        curObstacles.Add(obstacle);
        Enviroment enviroment = new NitrineParticleNebulae(curObstacles, 10);
        var segment = new Segment(enviroment);
        var curShips = new List<Ship>();
        curShips.Add(firstShip);
        curShips.Add(secondShip);
        curShips.Add(thirdShip);
        var segments = new List<Segment>();
        segments.Add(segment);
        var way = new Way(segments);
        var simulation = new Simulation(way, curShips);
        simulation.CheckShips();
        simulation.UpdateStatus();

        // Assert
        Assert.Equal(Results.TeamStatus.TeamDead, simulation.ResultsList[0].CurStatus);
        Assert.True(secondShip.IsAlive);
        Assert.True(thirdShip.IsAlive);
    }

    [Fact]
    public void Shortrouteinnormalspace()
    {
        // Short route in normal space + PleasureShuttle + Valkas
        Ship firstShip = new PleasureShuttle(); // most eefective
        Ship secondShip = new Vaklas();
        Enviroment enviroment = new NormalSpace(new List<Obstacle>(), 10);
        var segment = new Segment(enviroment);
        var segments = new List<Segment>();
        segments.Add(segment);
        var ships = new List<Ship>();
        ships.Add(firstShip);
        ships.Add(secondShip);
        var way = new Way(segments);
        var simulation = new Simulation(way, ships);
        simulation.CheckShips();
        simulation.UpdateStatus();
        Ship? mostEffectiveShip = simulation.MostEffectiveShip();

        // Assert
        Assert.IsType<PleasureShuttle>(mostEffectiveShip);
    }

    [Fact]
    public void Mediumlengthrouteinanebula()
    {
        // Medium-length route in a nebula of high spatial density + Augur + Stella
        Ship firstShip = new Augur();
        Ship secondShip = new Stella(); // most effective
        Enviroment enviroment = new NebulaeOfIncreasedDensityOfSpace(new List<Obstacle>(), 20);
        var segment = new Segment(enviroment);
        var segments = new List<Segment>();
        segments.Add(segment);
        var ships = new List<Ship>();
        ships.Add(firstShip);
        ships.Add(secondShip);
        var way = new Way(segments);
        var simulation = new Simulation(way, ships);
        simulation.CheckShips();
        simulation.UpdateStatus();
        Ship? mosteffectiveship = simulation.MostEffectiveShip();

        // Assert
        Assert.IsType<Stella>(mosteffectiveship);
    }

    [Fact]
    public void RoutethroughtheNitrine()
    {
        // Route through the Nitrine Particle Nebula + PleasureShuttle + Valkas
        Ship firstShip = new PleasureShuttle();
        Ship secondShip = new Vaklas(); // most effective
        Enviroment enviroment = new NitrineParticleNebulae(new List<Obstacle>(), 10);
        var segment = new Segment(enviroment);
        var segments = new List<Segment>();
        segments.Add(segment);
        var ships = new List<Ship>();
        ships.Add(firstShip);
        ships.Add(secondShip);
        var way = new Way(segments);
        var simulation = new Simulation(way, ships);
        simulation.CheckShips();
        simulation.UpdateStatus();
        Ship? mostEffectiveShip = simulation.MostEffectiveShip();

        // Asssert
        Assert.IsType<Vaklas>(mostEffectiveShip);
    }

    [Fact]
    public void TwoAsteroidsAndMeteoritinNormalSpaceAndNebulae()
    {
        Ship firstShip = new Augur(); // Dead
        Ship secondShip = new Meridian(); // Dead
        Ship thirdShip = new Stella(); // Alive
        Ship fourthShipShip = new Vaklas(); // Alive
        var obstacles = new List<Obstacle>() { new Asteroids(), new Asteroids(), new Meteorits() };
        Enviroment firstenviroment = new NormalSpace(obstacles, 10);
        Enviroment secondenviroment = new NebulaeOfIncreasedDensityOfSpace(new List<Obstacle>(), 20);
        var segments = new List<Segment>()
        {
            new Segment(firstenviroment), new Segment(secondenviroment),
        };
        var ships = new List<Ship>() { firstShip, secondShip, thirdShip, fourthShipShip };
        var way = new Way(segments);
        var simulation = new Simulation(way, ships);
        simulation.CheckShips();
        simulation.UpdateStatus();

        // Assert
        Assert.False(firstShip.IsAlive);
        Assert.False(secondShip.IsAlive);
        Assert.True(thirdShip.IsAlive);
        Assert.True(fourthShipShip.IsAlive);
    }
}