namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : ImpulseEngine
{
    public ImpulseEngineC()
        : base(EngineType.C)
    {
    }

    public override double CalculateFuelRequired(double fuelQuantity, int distance)
    {
        return fuelQuantity - (FuelConsumptionAe * distance);
    }
}