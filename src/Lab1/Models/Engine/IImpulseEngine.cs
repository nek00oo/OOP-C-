namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IImpulseEngine : IEngine
{
    public int Speed { get; }

    public void SlowingSpeed(int nitroParticlesSpeedEffectAe, int distance);
}