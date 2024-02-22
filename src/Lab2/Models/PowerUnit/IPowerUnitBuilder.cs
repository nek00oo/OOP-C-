using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;

public interface IPowerUnitBuilder
{
    IPowerUnitBuilder AddMaxLoadW(CountType maxLoadW);
    IPowerUnit Build();
}