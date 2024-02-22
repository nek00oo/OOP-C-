using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    private WiFiVersion _wiFiVersion;
    private PciEVersion _pciEVersion;

    internal WiFiAdapter(WiFiVersion wiFiVersion, PciEVersion pciEVersion, CountType powerConsumptionV)
    {
        _wiFiVersion = wiFiVersion;
        _pciEVersion = pciEVersion;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public IValidateResult IsWiFiCompatibility(IMotherboard motherboard)
    {
        if (motherboard is IMotherboardWithWiFiModule)
            return new IsNotCompability<IWiFiAdapter, IMotherboard>(this, motherboard);

        return new SuccessValidateResult.SuccessCompability();
    }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder wiFiAdapterBuilder)
    {
        wiFiAdapterBuilder.AddWiFiVersion(_wiFiVersion)
            .AddPciEVersion(_pciEVersion)
            .AddPowerConsumptionV(PowerConsumptionV);
        return wiFiAdapterBuilder;
    }
}