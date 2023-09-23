namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorThirdClass : DeflectorBase
{
    public DeflectorThirdClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorThirdClass *
                       ConstClass.DamageMeteoritesForDeflectorThirdClass;
    }
}