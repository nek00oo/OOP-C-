namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    public DeflectorSecondClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorSecondClass *
                       ConstClass.DamageMeteoritesForDeflectorSecondClass;
    }
}