namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    public DeflectorSecondClass()
        : base()
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorSecondClass *
                       ConstClass.DamageMeteoritesForDeflectorSecondClass;
    }
}