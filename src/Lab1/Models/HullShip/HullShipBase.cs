using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public abstract class HullShipBase
{
    protected int HealthPoints { get; set; }
    public bool IsDestroyed() => HealthPoints <= 0;

    public int TakeDamage(IObstaclesBase obstacle, int countObstacles)
    {
        if (!IsDestroyed())
            HealthPoints -= obstacle.Damage * countObstacles;
        return HealthPoints;
    }
}