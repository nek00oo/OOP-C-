using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public interface IRamMemory : IRamMemoryBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public bool IsRamMemoryCompatibility(IMotherboard motherboard);
}