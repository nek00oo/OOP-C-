using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IExternalMemory : IConsumeEnergy
{
    public CountType MemoryCapacityGb { get; }
}