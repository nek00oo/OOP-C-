namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineGamma : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeGammaEngine = 200;
    public int FuelConsumptionAe => FuelConsumptionAeJumpEngine;
    public int JumpRange => JumpRangeGammaEngine;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * distance * distance;
    }
}