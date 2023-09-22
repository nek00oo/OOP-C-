using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorSecondClass : DeflectorBase
{
    public DeflectorSecondClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorSecondClass *
                       ConstClass.DamageMeteoritesForDeflectorSecondClass;
    }

    public override bool ReflectObstacles(ObstaclesType obstaclesType, int countObstacles = 1)
    {
        if (IsDisabled()) return false;
        switch (obstaclesType)
        {
            case ObstaclesType.Asteroid:
                HealthPoints -= ConstClass.DamageAsteroidsForDeflectorSecondClass * countObstacles;
                return true;
            case ObstaclesType.Meteorite:
                HealthPoints -= ConstClass.DamageMeteoritesForDeflectorSecondClass * countObstacles;
                return true;
            case ObstaclesType.SpaceWhales: // TODO уничтожение корабля
                HealthPoints = 0;
                return false;
            case ObstaclesType.AntimatterFlares:
                if (IsDisabledPhotonDeflector()) return false;
                HealthPointPhotonDeflector--;
                return true;
            default:
                throw new InvalidOperationException("Non-existent type of obstacle");
        }
    }
}