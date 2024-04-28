using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class ProcessorRepository : RepositoryBase<Processor>
{
    public ProcessorRepository(IList<Processor> components)
        : base(components)
    {
    }
}