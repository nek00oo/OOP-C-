using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineE : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineE = 75;
    private const int SpeedImpulseEngineE = 5;

    public int Speed { get; } = SpeedImpulseEngineE;

    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAeImpulseEngineE * Math.Exp(distance);
    }

    public FlyResult FlyingSpace(ISpace space)
    {
        return new FlyResult.SuccessFlight(Math.Round(space.Distance / (double)Speed, 2));
    }
}