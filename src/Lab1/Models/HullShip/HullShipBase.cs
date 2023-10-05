using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public abstract class HullShipBase
{
    protected int HealthPoints { get; set; }
    public bool IsDestroyed() => HealthPoints <= 0;

    public abstract DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles);

    public DamageResult TakeDamageResult(int residualDamage)
    {
        if (IsDestroyed() is false)
            HealthPoints -= residualDamage;

        if (IsDestroyed())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}