using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class CaseRepository : RepositoryBase<ComputerCase>
{
    public CaseRepository(IList<ComputerCase> components)
        : base(components)
    {
    }
}