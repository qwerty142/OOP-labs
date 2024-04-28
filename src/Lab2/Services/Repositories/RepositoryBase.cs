using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class RepositoryBase<T> : IRepository<T>
    where T : IComponents
{
    private IList<T> _components;

    public RepositoryBase(IList<T> components)
    {
        _components = components;
    }

    public T GetByName(string name)
    {
        return _components.FirstOrDefault(component => component.Name == name) ??
               throw new NoComponentException("No component " + typeof(T));
    }

    public void Add(T sparePart)
    {
        _components.Add(sparePart);
    }

    public void Update(T sparePart)
    {
        T? component = _components.FirstOrDefault(component => component.Name == sparePart.Name);
        if (component is not null)
        {
            int pos = _components.IndexOf(component);
            _components[pos] = sparePart;
        }
    }

    public void Delete(string partName)
    {
        _components.Remove(_components.FirstOrDefault(elem => elem.Name == partName) ??
                           throw new NoComponentException("No " + typeof(T) + " with name " + partName));
    }
}