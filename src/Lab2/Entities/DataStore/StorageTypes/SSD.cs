namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore.StorageTypes;

public class SSD : Storage
{
    public SSD(int storageSize, double maxSpeed, double powerConsumption, string name, string connectionType)
        : base(storageSize, maxSpeed, powerConsumption, name, connectionType)
    {
    }
}