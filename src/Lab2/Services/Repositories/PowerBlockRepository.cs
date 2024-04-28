using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class PowerBlockRepository : RepositoryBase<PowerBlock>
{
    public PowerBlockRepository(IList<PowerBlock> components)
        : base(components)
    {
    }
}