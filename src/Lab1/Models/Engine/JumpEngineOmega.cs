using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeOmegaEngine = 125;
    private const double JumpTimeOmegaEngine = 2;
    public double FuelQuantity { get; private set; }
    public FlyResult FlyingSpaceСanal(int distance)
    {
        if (distance < JumpRangeOmegaEngine)
            return new FlyResult.SuccessFlight(JumpTimeOmegaEngine);
        return new FlyResult.ImpossibleFlight();
    }

    public void CalculateFuelRequired(int distance)
    {
       FuelQuantity += FuelConsumptionAeJumpEngine * distance * Math.Log2(distance);
    }
}