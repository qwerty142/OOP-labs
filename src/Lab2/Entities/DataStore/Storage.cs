using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.DataStore;

public abstract class Storage : IComponents
{
    protected Storage(int storageSize, double maxSpeed, double powerConsumption, string name, string connectionType)
    {
        if (storageSize <= 0 || maxSpeed <= 0 || powerConsumption <= 0 || connectionType is null || connectionType.Length == 0)
        {
            throw new ArgumentException("Incorrect parameters for SSD");
        }

        StorageSize = storageSize;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
        Name = name;
        ConnectionType = connectionType;
    }

    public int StorageSize { get; }
    public double MaxSpeed { get; }
    public double PowerConsumption { get; }
    public string Name { get; }
    public string ConnectionType { get; }
}