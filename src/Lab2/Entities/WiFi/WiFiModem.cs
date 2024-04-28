using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

public class WiFiModem : IComponents
{
    public WiFiModem(
        string versionOfStandard,
        bool builtInBluetoothModule,
        string pcieVersion,
        double powerConsumption,
        string name)
    {
        if (versionOfStandard is null ||
            versionOfStandard.Length == 0 ||
            pcieVersion is null ||
            pcieVersion.Length == 0 ||
            powerConsumption <= 0 ||
            name is null)
        {
            throw new ArgumentException("Incorrect parameters for WiFi modem");
        }

        VersionOfStandard = versionOfStandard;
        BuiltInBluetoothModule = builtInBluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string VersionOfStandard { get; }
    public bool BuiltInBluetoothModule { get; }
    public string PcieVersion { get; }
    public double PowerConsumption { get; }
    public string Name { get; }
}