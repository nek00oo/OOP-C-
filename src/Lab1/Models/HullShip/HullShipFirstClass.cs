using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipFirstClass : IHullShip
{
    private const int HealthPointsHullShipFirstClass = 100;

    public int HealthPoints { get; private set; } = HealthPointsHullShipFirstClass;

    public bool IsDestroyed() => HealthPoints <= 0;

    public DamageResult TakeDamageResult(int damage, int countObstacles)
    {
        if (IsDestroyed() is false)
            HealthPoints -= damage * countObstacles;
        if (IsDestroyed())
            return new DamageResult.Destroyed();
        return new DamageResult.DamageSustained();
    }
}