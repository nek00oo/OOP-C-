using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : HullShipBase
{
    private const int HealthPointsHullShipThirdClass = 252;
    private const int CoefficientAbsorptionSmallDamageForHullShipThirdClass = 5;
    private const int CoefficientAbsorptionAverageDamageForHullShipThirdClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public HullShipThirdClass()
    {
        HealthPoints = HealthPointsHullShipThirdClass;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (obstacle.Damage < SmallDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForHullShipThirdClass * countObstacles;
            else if (obstacle.Damage < AverageDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionAverageDamageForHullShipThirdClass * countObstacles;
            else
                HealthPoints -= obstacle.Damage * countObstacles;
        }

        if (IsDestroyed())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}