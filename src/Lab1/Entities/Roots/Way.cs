using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Roots;

public class Way
{
    public Way(IEnumerable<Segment> segments)
    {
        Segment = segments.ToList();
    }

    public IList<Segment> Segment { get; }
}