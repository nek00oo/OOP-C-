using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

public interface IPowerUnit : IPowerUnitBuilderDirect, IComputerComponent
{
    public CountType MaxLoadW { get; }
    public bool TotalSystemConsumption(IReadOnlyCollection<IRamMemory> ramMemories, IReadOnlyCollection<IExternalMemory> externalMemories, params IConsumeEnergy[] consumeEnergies);
}