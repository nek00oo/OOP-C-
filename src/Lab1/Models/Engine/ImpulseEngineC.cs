namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : IImpulseEngine
{
    public int FuelConsumptionAe { get; } = 50;

    public int Speed { get; private set; } = 50;
    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAe * distance;
    }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance;
    }
}