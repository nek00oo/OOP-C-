namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorFirstClass : DeflectorBase
{
    public DeflectorFirstClass()
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorFirstClass *
                       ConstClass.DamageMeteoritesForDeflectorFirstClass;
    }
}