using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

public class PowerUnit : IPowerUnit
{
    public PowerUnit(CountType maxLoadW)
    {
        MaxLoadW = maxLoadW;
    }

    public CountType MaxLoadW { get; }

    public bool TotalSystemConsumption(params IConsumeEnergy[] consumeEnergies)
    {
        throw new System.NotImplementedException();
    }

    public IPowerUnitBuilder Direct(IPowerUnitBuilder powerUnitBuilder)
    {
        powerUnitBuilder.AddMaxLoadW(MaxLoadW);
        return powerUnitBuilder;
    }
}