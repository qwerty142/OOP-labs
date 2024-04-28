using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class CoolerRepository : RepositoryBase<Cooler>
{
    public CoolerRepository(IList<Cooler> components)
        : base(components)
    {
    }
}