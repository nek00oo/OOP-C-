using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : IImpulseEngine
{
    public int FuelConsumptionAe { get; } = 75;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * Math.Exp(distance);
    }
}