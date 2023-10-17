using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapterWithBluetoothBuilder : IWiFiAdapterWithBluetoothBuilder
{
    private WiFiVersion? _wiFiVersion;
    private PciEVersion? _pciEVersion;
    private CountType? _powerConsumptionV;
    private BluetoothVersion? _bluetoothVersion;

    public IWiFiAdapterBuilder AddWiFiVersion(WiFiVersion wiFiVersion)
    {
        _wiFiVersion = wiFiVersion;
        return this;
    }

    public IWiFiAdapterBuilder AddPciEVersion(PciEVersion pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public IWiFiAdapterBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        _powerConsumptionV = powerConsumptionV;
        return this;
    }

    public IWiFiAdapterWithBluetoothBuilder AddBluetoothVersion(BluetoothVersion bluetoothVersion)
    {
        _bluetoothVersion = bluetoothVersion;
        return this;
    }

    public IWiFiAdapter Build()
    {
        return new WiFiAdapterWithBluetooth(
            _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
            _bluetoothVersion ?? throw new ArgumentNullException(nameof(_bluetoothVersion)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _powerConsumptionV ?? throw new ArgumentNullException(nameof(_powerConsumptionV)));
    }
}