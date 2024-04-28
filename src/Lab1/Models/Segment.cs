using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record Segment
{
    public Segment(Enviroment enviroment)
    {
        this.Enviroment = enviroment;
    }

    public Enviroment Enviroment { get; init; }
}
