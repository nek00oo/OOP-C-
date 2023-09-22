using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : ImpulseEngine
{
    public ImpulseEngineE()
        : base(EngineType.E)
    {
    }

    public override double CalculateFuelRequired(double fuelQuantity, int distance)
    {
        return fuelQuantity - (FuelConsumptionAe * Math.Exp(distance));
    }
}