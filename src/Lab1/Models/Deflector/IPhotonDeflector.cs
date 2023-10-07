using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public interface IPhotonDeflector
{
    public int HealthPointPhotonDeflector { get; }
    public bool TakeDamagePhotonDeflector(ObstacleAntimatterFlares antimatterFlares, int countObstacles);
    public bool IsDisabledPhotonDeflector();
}