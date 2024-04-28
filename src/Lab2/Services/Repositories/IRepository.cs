namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public interface IRepository<T>
{
    T? GetByName(string name);
    void Add(T sparePart);
    void Update(T sparePart);
    void Delete(string partName);
}