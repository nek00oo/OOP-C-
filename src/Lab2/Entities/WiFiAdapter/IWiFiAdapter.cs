using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiAdapter : IWiFiAdapterBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsWiFiCompatibility(IMotherboard motherboard);
}