using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IRamMemoryBuilderComputer
{
    IVideoCardOrExternalMemoryBuilderComputer AddRamMemory(IRamMemory ramMemory);
}