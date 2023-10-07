using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
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

    public DamageResult TakeDamageResult(IObstacle obstacle, int countObstacles)
    {
        if (IsDisabled())
            return new DamageResult.DamageOverflow(countObstacles);
        for (int i = 0; i < countObstacles; i++)
        {
            if (obstacle.Damage < SmallDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionSmallDamageForDeflectorSecondClass * countObstacles;
            else if (obstacle.Damage < AverageDamage)
                HealthPoints -= obstacle.Damage / CoefficientAbsorptionAverageDamageForDeflectorSecondClass * countObstacles;
            else
                HealthPoints -= obstacle.Damage * countObstacles;
            if (IsDisabled())
                return new DamageResult.DamageOverflow(countObstacles - i);
        }

        return new DamageResult.DamageSustained();
    }
}