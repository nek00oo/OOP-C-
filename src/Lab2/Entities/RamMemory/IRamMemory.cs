using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public interface IRamMemory : IRamMemoryBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsRamMemoryCompatibility(IMotherboard motherboard);
}