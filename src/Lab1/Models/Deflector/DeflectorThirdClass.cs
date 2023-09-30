namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorThirdClass : DeflectorBase
{
    public DeflectorThirdClass()
        : base()
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorThirdClass *
                       ConstClass.DamageMeteoritesForDeflectorThirdClass;
    }
}