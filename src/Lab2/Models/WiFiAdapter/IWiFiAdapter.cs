using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

public interface IWiFiAdapter : IWiFiAdapterBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsWiFiCompatibility(IMotherboard motherboard);
}