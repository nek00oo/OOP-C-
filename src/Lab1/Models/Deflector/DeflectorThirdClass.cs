using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorThirdClass : DeflectorBase
{
    private const int HealthPointsDeflectorThirdClass = 300;
    private const int CoefficientAbsorptionSmallDamageForDeflectorThirdClass = 8;
    private const int CoefficientAbsorptionAverageDamageForDeflectorThirdClass = 4;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public override int HealthPoints { get; protected set; } = HealthPointsDeflectorThirdClass;

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (obstacle.Damage < SmallDamage)
            HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForDeflectorThirdClass * countObstacles;
        else if (obstacle.Damage < AverageDamage)
            HealthPoints -= obstacle.Damage / CoefficientAbsorptionAverageDamageForDeflectorThirdClass * countObstacles;
        else
            HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDisabled())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}