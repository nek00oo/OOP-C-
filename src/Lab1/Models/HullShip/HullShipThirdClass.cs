using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : HullShipBase
{
    public HullShipThirdClass()
    {
        HealthPoints = 101;
    }

    public override int TakeDamage(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
            HealthPoints -= (obstacle.Damage / 5) * countObstacles;
        return HealthPoints;
    }
}