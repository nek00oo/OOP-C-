using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    public DeflectorSecondClass()
    {
        HealthPoints = 150;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        if (obstacle.Damage < 70)
            HealthPoints -= obstacle.Damage / 4 * countObstacles;
        else if (obstacle.Damage < 170)
            HealthPoints -= obstacle.Damage / 2 * countObstacles;
        else
            HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDisabled())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}