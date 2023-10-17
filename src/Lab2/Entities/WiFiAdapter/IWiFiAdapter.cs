using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiAdapter : IWiFiAdapterBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public bool IsWiFiCompatibility(IMotherboard motherboard);
}