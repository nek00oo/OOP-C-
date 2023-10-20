using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : IHullShip
{
    private const int HealthPointsHullShipThirdClass = 252;
    private const int CoefficientAbsorptionSmallDamageForHullShipThirdClass = 5;
    private const int CoefficientAbsorptionAverageDamageForHullShipThirdClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;

    public int HealthPoints { get; private set; } = HealthPointsHullShipThirdClass;
    public bool IsDestroyed() => HealthPoints <= 0;

    public DamageResult TakeDamageResult(int damage, int countObstacles)
    {
        if (IsDestroyed() is false)
        {
            if (damage < SmallDamage)
                HealthPoints -= damage / CoefficientAbsorptionSmallDamageForHullShipThirdClass * countObstacles;
            else if (damage < AverageDamage)
                HealthPoints -= damage / CoefficientAbsorptionAverageDamageForHullShipThirdClass * countObstacles;
            else
                HealthPoints -= damage * countObstacles;
        }

        if (IsDestroyed())
            return new DamageResult.Destroyed();
        return new DamageResult.DamageSustained();
    }
}