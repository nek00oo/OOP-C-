using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorFirstClass : DeflectorBase
{
    private const int HealthPointsDeflectorFirstClass = 60;
    private const int CoefficientAbsorptionSmallDamageForDeflectorFirstClass = 2;
    private const int SmallDamage = 70;
    public override int HealthPoints { get; protected set; } = HealthPointsDeflectorFirstClass;

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (obstacle.Damage < SmallDamage)
            HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForDeflectorFirstClass * countObstacles;
        else
            HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDisabled())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}