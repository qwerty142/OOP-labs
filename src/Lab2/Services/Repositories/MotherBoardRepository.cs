using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoardAndHerComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class MotherBoardRepository : RepositoryBase<MotherBoard>
{
    public MotherBoardRepository(IList<MotherBoard> components)
        : base(components)
    {
    }
}