using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineAlpha : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeAlphaEngine = 50;
    private const double JumpTimeAlphaEngine = 3;

    public FlyResult FlyingSpaceСanal(int distance)
    {
        CalculateFuelRequired(distance);
        if (distance < JumpRangeAlphaEngine)
            return new FlyResult.SuccessFlight(JumpTimeAlphaEngine, new UsageFuelGravitonMatter(CalculateFuelRequired(distance)));
        return new FlyResult.ImpossibleFlight();
    }

    private static double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAeJumpEngine * distance;
    }
}