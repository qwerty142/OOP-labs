using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class StorageRepository : RepositoryBase<Storage>
{
    public StorageRepository(IList<Storage> components)
        : base(components)
    {
    }
}