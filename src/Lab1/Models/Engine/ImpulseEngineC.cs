namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : IImpulseEngine
{
    public int FuelConsumptionAe { get; } = 50;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * distance;
    }
}