using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IImpulseEngine : IEngine, IFuelUsageActivePlasma
{
    public int Speed { get; }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance);
}