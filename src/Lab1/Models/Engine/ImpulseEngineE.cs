using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineE = 75;
    private const int SpeedImpulseEngineE = 5;
    public int FuelConsumptionAe => FuelConsumptionAeImpulseEngineE;

    public int Speed { get; private set; } = SpeedImpulseEngineE;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * Math.Exp(distance);
    }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance / 10;
    }
}