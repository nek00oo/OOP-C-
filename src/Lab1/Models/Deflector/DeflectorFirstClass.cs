namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorFirstClass : DeflectorBase
{
    public DeflectorFirstClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorFirstClass *
                       ConstClass.DamageMeteoritesForDeflectorFirstClass;
    }
}