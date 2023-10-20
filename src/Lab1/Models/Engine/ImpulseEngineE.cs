using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineE = 75;
    private const int SpeedImpulseEngineE = 5;

    private double Speed { get; } = SpeedImpulseEngineE;

    public FlyResult FlyingSpace(int distance, double speedEffectAe)
    {
        CalculateFuelRequired(distance);
        return new FlyResult.SuccessFlight(Math.Round(distance / (double)Speed, 2), new UsageFuelActivePlasma(CalculateFuelRequired(distance)));
    }

    private static double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAeImpulseEngineE * Math.Exp(distance);
    }
}