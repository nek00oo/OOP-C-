using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipFirstClass : HullShipBase
{
    private const int HealthPointsHullShipFirstClass = 100;
    public HullShipFirstClass()
    {
        HealthPoints = HealthPointsHullShipFirstClass;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
            HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDestroyed())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}