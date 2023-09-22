using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorThirdClass : DeflectorBase
{
    public DeflectorThirdClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorThirdClass *
                       ConstClass.DamageMeteoritesForDeflectorThirdClass;
    }

    public override bool ReflectObstacles(ObstaclesType obstaclesType, int countObstacles = 1)
    {
        if (IsDisabled()) return false;
        switch (obstaclesType)
        {
            case ObstaclesType.Asteroid:
                HealthPoints -= ConstClass.DamageAsteroidsForDeflectorThirdClass * countObstacles;
                return true;
            case ObstaclesType.Meteorite:
                HealthPoints -= ConstClass.DamageMeteoritesForDeflectorThirdClass * countObstacles;
                return true;
            case ObstaclesType.SpaceWhales:
                HealthPoints = 0;
                return true;
            case ObstaclesType.AntimatterFlares: // TODO Иначе смерть экипажа
                if (IsDisabledPhotonDeflector()) return false;
                HealthPointPhotonDeflector--;
                return true;
            default:
                throw new InvalidOperationException("Non-existent type of obstacle");
        }
    }
}