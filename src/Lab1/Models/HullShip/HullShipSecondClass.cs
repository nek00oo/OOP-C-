using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    private const int HealthPointsHullShipSecondClass = 120;
    private const int CoefficientAbsorptionSmallDamageForHullShipSecondClass = 3;
    private const int CoefficientAbsorptionAverageDamageForHullShipSecondClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public HullShipSecondClass()
    {
        HealthPoints = HealthPointsHullShipSecondClass;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (obstacle.Damage < SmallDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForHullShipSecondClass * countObstacles;
            else if (obstacle.Damage < AverageDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionAverageDamageForHullShipSecondClass * countObstacles;
            else
                HealthPoints -= obstacle.Damage * countObstacles;
        }

        if (IsDestroyed())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}