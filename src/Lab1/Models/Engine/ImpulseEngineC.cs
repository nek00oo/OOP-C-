using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineC = 50;
    private const int SpeedImpulseEngineC = 2;
    public double Speed { get; private set; } = SpeedImpulseEngineC;

    public FlyResult FlyingSpace(int distance, double speedEffectAe)
    {
        SlowingSpeed(speedEffectAe, distance);
        if (Speed > 0)
            return new FlyResult.SuccessFlight(Math.Round(distance / (double)Speed, 2), new UsageFuelActivePlasma(CalculateFuelRequired(distance)));
        return new FlyResult.ImpossibleFlight();
    }

    private static double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAeImpulseEngineC * distance;
    }

    private void SlowingSpeed(double nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance;
    }
}