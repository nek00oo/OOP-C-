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
    public abstract bool ReflectObstacles(ObstaclesType obstaclesType, int countObstacles = 1);

    public abstract bool TakeDamage(int count = 1);
}
