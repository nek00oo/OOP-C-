namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class ImpulseEngineC : IImpulseEngine
{
    private const int FuelConsumptionAeImpulseEngineC = 50;
    private const int SpeedImpulseEngineC = 2;
    public int FuelConsumptionAe => FuelConsumptionAeImpulseEngineC;

    public int Speed { get; private set; } = SpeedImpulseEngineC;

    public double CalculateFuelRequired(int distance)
    {
        return FuelConsumptionAe * distance;
    }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance)
    {
        Speed -= nitroParticlesSpeedEffectAe * distance / 4;
    }
}