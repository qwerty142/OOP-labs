using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines.EngineType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengths;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Ship
{
    public Ship(Deflector? deflector, Engine engine, JumpEngine? jumpEngine, HullStrength? hull)
    {
        this.Deflector = deflector;
        this.Engine = engine;
        this.JumpEngine = jumpEngine;
        this.Hull = hull;
        this.IsAlive = true;
    }

    public bool IsAlive { get; private set; }
    public Deflector? Deflector { get; }
    public Engine? Engine { get; }
    public JumpEngine? JumpEngine { get; }
    public HullStrength? Hull { get; }

    public void TakeDamage(Obstacle obstacle)
    {
        obstacle = obstacle ?? throw new ArgumentNullException(nameof(obstacle));
        this.Deflector?.TakeDamage(obstacle);
        if (Deflector != null) this.Hull?.TakeDamage(obstacle, Deflector);
        if (obstacle.DamageValue > 0)
        {
            this.IsAlive = false;
        }
    }

    public void ReNewStatus(bool newstatus)
    {
        this.IsAlive = newstatus;
    }
}