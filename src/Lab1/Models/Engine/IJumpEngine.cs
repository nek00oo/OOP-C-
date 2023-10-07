using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IJumpEngine : IFuelUsageGravitonMatter
{
    public FlyResult FlyingSpaceСanal(int distance);
}