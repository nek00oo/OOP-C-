using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    public HullShipSecondClass()
    {
        HealthPoints = 101;
    }

    public override int TakeDamage(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
            HealthPoints -= (obstacle.Damage * obstacle.Weight / 3) * countObstacles;
        return HealthPoints;
    }
}