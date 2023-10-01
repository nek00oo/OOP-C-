using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    public DeflectorSecondClass()
    {
        HealthPoints = 100;
    }

    public override int TakeDamage(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDisabled() is false)
            HealthPoints -= obstacle.Damage * countObstacles;
        return IsDisabled() ? HealthPoints : 0;
    }
}