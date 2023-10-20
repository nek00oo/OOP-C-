using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : IDeflector
{
    private const int HealthPointsDeflectorSecondClass = 150;
    private const int CoefficientAbsorptionSmallDamageForDeflectorSecondClass = 4;
    private const int CoefficientAbsorptionAverageDamageForDeflectorSecondClass = 2;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public int HealthPoints { get; private set; } = HealthPointsDeflectorSecondClass;
    public bool IsDisabled() => HealthPoints < 0;

    public DamageResult TakeDamageResult(int damage, int countObstacles)
    {
        if (IsDisabled())
            return new DamageResult.DamageOverflow(countObstacles);
        for (int i = 0; i < countObstacles; i++)
        {
            if (damage < SmallDamage)
                HealthPoints -= damage / CoefficientAbsorptionSmallDamageForDeflectorSecondClass * countObstacles;
            else if (damage < AverageDamage)
                HealthPoints -= damage / CoefficientAbsorptionAverageDamageForDeflectorSecondClass * countObstacles;
            else
                HealthPoints -= damage * countObstacles;
            if (IsDisabled())
                return new DamageResult.DamageOverflow(countObstacles - i);
        }

        return new DamageResult.DamageSustained();
    }
}