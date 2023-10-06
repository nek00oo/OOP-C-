using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    private const int HealthPointsDeflectorSecondClass = 150;
    private const int CoefficientAbsorptionSmallDamageForDeflectorSecondClass = 4;
    private const int CoefficientAbsorptionAverageDamageForDeflectorSecondClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public override int HealthPoints { get; protected set; } = HealthPointsDeflectorSecondClass;

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (obstacle.Damage < SmallDamage)
            HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForDeflectorSecondClass * countObstacles;
        else if (obstacle.Damage < AverageDamage)
            HealthPoints -= obstacle.Damage / CoefficientAbsorptionAverageDamageForDeflectorSecondClass * countObstacles;
        else
            HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDisabled())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}