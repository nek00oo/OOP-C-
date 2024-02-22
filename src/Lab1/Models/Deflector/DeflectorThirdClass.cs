using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorThirdClass : IDeflector
{
    private const int HealthPointsDeflectorThirdClass = 300;
    private const int CoefficientAbsorptionSmallDamageForDeflectorThirdClass = 8;
    private const int CoefficientAbsorptionAverageDamageForDeflectorThirdClass = 4;
    private const int SmallDamage = 70;
    private const int AverageDamage = 170;
    public int HealthPoints { get; private set; } = HealthPointsDeflectorThirdClass;
    public bool IsDisabled() => HealthPoints < 0;

    public DamageResult TakeDamageResult(int damage, int countObstacles)
    {
        if (IsDisabled())
            return new DamageResult.DamageOverflow(countObstacles);
        for (int i = 0; i < countObstacles; i++)
        {
            if (damage < SmallDamage)
                HealthPoints -= damage / CoefficientAbsorptionSmallDamageForDeflectorThirdClass * countObstacles;
            else if (damage < AverageDamage)
                HealthPoints -= damage / CoefficientAbsorptionAverageDamageForDeflectorThirdClass * countObstacles;
            else
                HealthPoints -= damage * countObstacles;
            if (IsDisabled())
                return new DamageResult.DamageOverflow(countObstacles - i);
        }

        return new DamageResult.DamageSustained();
    }
}