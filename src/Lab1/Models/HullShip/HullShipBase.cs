using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public abstract class HullShipBase
{
    protected int HealthPoints { get; set; }
    public bool IsDestroyed() => HealthPoints <= 0;

    public abstract int TakeDamage(IObstaclesBase obstacle, int countObstacles);

    public int TakeDamage(int residualDamage)
    {
        if (IsDestroyed() is false)
            HealthPoints += residualDamage;
        return HealthPoints;
    }
}