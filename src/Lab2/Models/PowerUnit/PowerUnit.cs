using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;

public class PowerUnit : IPowerUnit
{
    internal PowerUnit(CountType maxLoadW)
    {
        MaxLoadW = maxLoadW;
    }

    public CountType MaxLoadW { get; }

    public IValidateResult IsPowerUnitCompatibility(IEnumerable<IConsumeEnergy> consumeEnergies)
    {
        double totalSystemConsumption = consumeEnergies.Sum(x => x.PowerConsumptionV.Count);

        if (totalSystemConsumption > MaxLoadW.Count * 1.2)
            return new NegativeValidateResult.InsufficientPowerThePowerUnit();
        if (totalSystemConsumption > MaxLoadW.Count && totalSystemConsumption < MaxLoadW.Count * 1.2)
            return new SuccessValidateResult.FailureComplyWithRecommendedPowerPowerUnit();

        return new SuccessValidateResult.SuccessCompability();
    }

    public IPowerUnitBuilder Direct(IPowerUnitBuilder powerUnitBuilder)
    {
        powerUnitBuilder.AddMaxLoadW(MaxLoadW);
        return powerUnitBuilder;
    }
}