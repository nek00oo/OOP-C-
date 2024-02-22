using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;

public interface IRamMemory : IRamMemoryBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsRamMemoryCompatibility(IMotherboard motherboard);
}