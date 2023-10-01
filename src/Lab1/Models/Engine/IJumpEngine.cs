using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IJumpEngine : IEngine, IFuelUsageGravitonMatter
{
    public int JumpRange { get; }
}