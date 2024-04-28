using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships.ShipTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record Results
{
    public Results()
    {
        this.AmountOfFuel = 0;
        CurrentShip = new PleasureShuttle();
        CurStatus = TeamStatus.Alive;

        // Корабль может быть любым, ведь при создании любого Results будет изменен корабль
    }

    public enum TeamStatus
    {
        Alive,
        TeamDead,
        Lost,
    }

    public TeamStatus CurStatus { get; set; }
    public float AmountOfFuel { get; set; }
    public Ship CurrentShip { get; set; }
}