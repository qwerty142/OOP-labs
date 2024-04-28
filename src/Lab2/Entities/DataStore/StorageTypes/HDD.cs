namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore.StorageTypes;

public class HDD : Storage
{
    public HDD(int storageSize, double maxSpeed, double powerConsumption, string name, string connectionType)
        : base(storageSize, maxSpeed, powerConsumption, name, connectionType)
    {
    }
}