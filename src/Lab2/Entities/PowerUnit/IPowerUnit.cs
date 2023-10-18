using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

public interface IPowerUnit : IPowerUnitBuilderDirect, IComputerComponent
{
    public CountType MaxLoadW { get; }
    public bool TotalSystemConsumption(params IConsumeEnergy[] consumeEnergies);
}