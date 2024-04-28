using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class RandomAccessMemoryRepository : RepositoryBase<RandomAccessMemory>
{
    public RandomAccessMemoryRepository(IList<RandomAccessMemory> components)
        : base(components)
    {
    }
}