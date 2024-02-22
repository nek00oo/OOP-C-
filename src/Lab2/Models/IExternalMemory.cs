using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IExternalMemory : IConsumeEnergy
{
    public CountType MemoryCapacityGb { get; }
}