namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineAlpha : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeAlphaEngine = 50;
    public int FuelConsumptionAe => FuelConsumptionAeJumpEngine;
    public int JumpRange => JumpRangeAlphaEngine;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * distance;
    }
}