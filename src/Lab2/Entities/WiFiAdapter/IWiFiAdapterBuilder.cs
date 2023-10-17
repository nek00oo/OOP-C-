using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder AddWiFiVersion(WiFiVersion wiFiVersion);
    IWiFiAdapterBuilder AddPciEVersion(PciEVersion pciEVersion);
    IWiFiAdapterBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IWiFiAdapter Build();
}