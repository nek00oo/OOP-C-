using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapterWithBluetooth : IWiFiAdapter, IBluetoothCapable
{
    private WiFiVersion _wiFiVersion;
    private PciEVersion _pciEVersion;

    public WiFiAdapterWithBluetooth(WiFiVersion wiFiVersion, BluetoothVersion bluetoothVersion, PciEVersion pciEVersion, CountType powerConsumptionV)
    {
        _wiFiVersion = wiFiVersion;
        _pciEVersion = pciEVersion;
        BluetoothVersion = bluetoothVersion;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }
    public BluetoothVersion BluetoothVersion { get; }

    public bool IsWiFiCompatibility(IMotherboard motherboard)
    {
        return motherboard is not IMotherboardWithWiFiModule;
    }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder wiFiAdapterBuilder)
    {
        if (wiFiAdapterBuilder is IWiFiAdapterWithBluetoothBuilder wiFiAdapterWithBluetoothBuilder)
        {
            wiFiAdapterWithBluetoothBuilder.AddWiFiVersion(_wiFiVersion);
            wiFiAdapterWithBluetoothBuilder.AddPciEVersion(_pciEVersion);
            wiFiAdapterWithBluetoothBuilder.AddBluetoothVersion(BluetoothVersion);
            wiFiAdapterWithBluetoothBuilder.AddPowerConsumptionV(PowerConsumptionV);
            return wiFiAdapterWithBluetoothBuilder;
        }

        wiFiAdapterBuilder.AddWiFiVersion(_wiFiVersion);
        wiFiAdapterBuilder.AddPciEVersion(_pciEVersion);
        wiFiAdapterBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return wiFiAdapterBuilder;
    }
}