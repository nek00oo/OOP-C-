using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeOmegaEngine = 125;
    public int FuelConsumptionAe => FuelConsumptionAeJumpEngine;
    public int JumpRange => JumpRangeOmegaEngine;

    public double CalculateFuelRequired(int distance)
    {
       return FuelConsumptionAe * distance * Math.Log2(distance);
    }
}