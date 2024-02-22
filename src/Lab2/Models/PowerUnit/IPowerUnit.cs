using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;

public interface IPowerUnit : IPowerUnitBuilderDirect, IComputerComponent
{
    public CountType MaxLoadW { get; }
    public IValidateResult IsPowerUnitCompatibility(IEnumerable<IConsumeEnergy> consumeEnergies);
}