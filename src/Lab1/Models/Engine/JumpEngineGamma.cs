using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineGamma : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeGammaEngine = 200;
    private const double JumpTimeGammaEngine = 1;

    public double FuelQuantity { get; private set; }

    public FlyResult FlyingSpaceСanal(int distance)
    {
        CalculateFuelRequired(distance);
        if (distance < JumpRangeGammaEngine)
            return new FlyResult.SuccessFlight(JumpTimeGammaEngine, new UsageFuelGravitonMatter(CalculateFuelRequired(distance)));
        return new FlyResult.ImpossibleFlight();
    }

    private static double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAeJumpEngine * distance * distance;
    }
}