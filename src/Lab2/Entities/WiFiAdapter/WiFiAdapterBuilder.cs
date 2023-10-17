using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private WiFiVersion? _wiFiVersion;
    private PciEVersion? _pciEVersion;
    private CountType? _powerConsumptionV;

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

    public IWiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _powerConsumptionV ?? throw new ArgumentNullException(nameof(_powerConsumptionV)));
    }
}