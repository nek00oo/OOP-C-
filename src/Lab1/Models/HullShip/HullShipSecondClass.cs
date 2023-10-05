using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    public HullShipSecondClass()
    {
        HealthPoints = 120;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (obstacle.Damage < 65)
                HealthPoints -= obstacle.Damage / 3 * countObstacles;
            else if (obstacle.Damage < 170)
                HealthPoints -= obstacle.Damage / 2 * countObstacles;
            else
                HealthPoints -= obstacle.Damage * countObstacles;
        }

        if (IsDestroyed())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}