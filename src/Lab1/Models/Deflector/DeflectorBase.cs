using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorBase
{
    protected DeflectorBase(bool photonDeflector)
    {
        if (photonDeflector)
            HealthPointPhotonDeflector = ConstClass.HealthPointPhotonDeflector;
        else HealthPointPhotonDeflector = 0;
    }

    public int HealthPointPhotonDeflector { get; protected set; }
    protected int HealthPoints { get; set; }
    public bool IsDisabledPhotonDeflector() => HealthPointPhotonDeflector <= 0;
    public bool IsDisabled() => HealthPoints <= 0;

    public bool TakeDamage(IObstaclesBase obstacle, int count = 1)
    {
        HealthPoints -= obstacle.Damage * count;
        return HealthPoints > 0;
    }
}
