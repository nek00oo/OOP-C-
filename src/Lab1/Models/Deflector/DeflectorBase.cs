using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorBase
{
    protected int HealthPoints { get; set; }
    public bool IsDisabled() => HealthPoints <= 0;

    public int TakeDamage(IObstaclesBase obstacle, int countObstacles)
    {
        if (!IsDisabled())
            HealthPoints -= obstacle.Damage * countObstacles;
        return IsDisabled() ? HealthPoints : 0;
    }
}
