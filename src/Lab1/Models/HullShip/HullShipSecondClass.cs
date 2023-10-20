using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : IHullShip
{
    private const int HealthPointsHullShipSecondClass = 120;
    private const int CoefficientAbsorptionSmallDamageForHullShipSecondClass = 3;
    private const int CoefficientAbsorptionAverageDamageForHullShipSecondClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;

    public int HealthPoints { get; private set; } = HealthPointsHullShipSecondClass;
    public bool IsDestroyed() => HealthPoints <= 0;
    public DamageResult TakeDamageResult(int damage, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (damage < SmallDamage)
                HealthPoints -= damage / CoefficientAbsorptionSmallDamageForHullShipSecondClass * countObstacles;
            else if (damage < AverageDamage)
                HealthPoints -= damage / CoefficientAbsorptionAverageDamageForHullShipSecondClass * countObstacles;
            else
                HealthPoints -= damage * countObstacles;
        }

        if (IsDestroyed())
            return new DamageResult.Destroyed();
        return new DamageResult.DamageSustained();
    }
}