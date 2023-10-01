using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorFirstClass : DeflectorBase
{
    public DeflectorFirstClass()
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