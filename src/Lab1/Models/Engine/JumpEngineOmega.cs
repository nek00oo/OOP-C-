using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeOmegaEngine = 125;
    private const double JumpTimeOmegaEngine = 2;
    public FlyResult FlyingSpaceСanal(int distance)
    {
        CalculateFuelRequired(distance);
        if (distance < JumpRangeOmegaEngine)
            return new FlyResult.SuccessFlight(JumpTimeOmegaEngine, new UsageFuelGravitonMatter(CalculateFuelRequired(distance)));
        return new FlyResult.ImpossibleFlight();
    }

    private static double CalculateFuelRequired(int distance)
    {
       return FuelConsumptionAeJumpEngine * distance * Math.Log2(distance);
    }
}