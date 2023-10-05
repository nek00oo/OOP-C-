using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : HullShipBase
{
    public HullShipThirdClass()
    {
        HealthPoints = 252;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (obstacle.Damage < 65)
                HealthPoints -= obstacle.Damage / 5 * countObstacles;
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