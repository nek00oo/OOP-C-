using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineC = 50;
    private const int SpeedImpulseEngineC = 2;
    public int Speed { get; private set; } = SpeedImpulseEngineC;

    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAeImpulseEngineC * distance;
    }

    public FlyResult FlyingSpace(ISpace space)
    {
        if (space is NebulaeNeutrinoParticles nebulaeNeutrinoParticles)
            SlowingSpeed(nebulaeNeutrinoParticles.NitroParticlesSpeedEffectAe, nebulaeNeutrinoParticles.Distance);
        if (Speed > 0)
            return new FlyResult.SuccessFlight(Math.Round(space.Distance / (double)Speed, 2));
        return new FlyResult.ImpossibleFlight();
    }

    private void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance / 4;
    }
}