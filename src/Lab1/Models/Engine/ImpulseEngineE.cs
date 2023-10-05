using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : IImpulseEngine
{
    public int FuelConsumptionAe { get; } = 75;

    public int Speed { get; private set; } = 150;
    public double FuelQuantity { get; private set; }

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * Math.Exp(distance);
    }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance / 4;
    }
}