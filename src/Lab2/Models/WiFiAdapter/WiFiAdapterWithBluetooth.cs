using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

public class WiFiAdapterWithBluetooth : IWiFiAdapter, IBluetoothCapable
{
    private WiFiVersion _wiFiVersion;
    private PciEVersion _pciEVersion;

    internal WiFiAdapterWithBluetooth(WiFiVersion wiFiVersion, BluetoothVersion bluetoothVersion, PciEVersion pciEVersion, CountType powerConsumptionV)
    {
        _wiFiVersion = wiFiVersion;
        _pciEVersion = pciEVersion;
        BluetoothVersion = bluetoothVersion;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }
    public BluetoothVersion BluetoothVersion { get; }

    public IValidateResult IsWiFiCompatibility(IMotherboard motherboard)
    {
        if (motherboard is IMotherboardWithWiFiModule)
            return new IsNotCompability<IWiFiAdapter, IMotherboard>(this, motherboard);

        return new SuccessValidateResult.SuccessCompability();
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

        wiFiAdapterBuilder.AddWiFiVersion(_wiFiVersion)
            .AddPciEVersion(_pciEVersion)
            .AddPowerConsumptionV(PowerConsumptionV);
        return wiFiAdapterBuilder;
    }
}