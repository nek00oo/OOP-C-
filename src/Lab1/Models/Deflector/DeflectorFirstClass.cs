using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class DeflectorFirstClass : DeflectorBase
{
    public DeflectorFirstClass(bool photonDeflector)
        : base(photonDeflector)
    {
        HealthPoints = ConstClass.DamageAsteroidsForDeflectorFirstClass *
                       ConstClass.DamageMeteoritesForDeflectorFirstClass;
    }

    public override bool ReflectObstacles(ObstaclesType obstaclesType, int countObstacles = 1)
    {
        if (IsDisabled()) return false;
        switch (obstaclesType)
        {
            case ObstaclesType.Asteroid:
                HealthPoints -= ConstClass.DamageAsteroidsForDeflectorFirstClass * countObstacles;
                return true;
            case ObstaclesType.Meteorite:
                HealthPoints -= ConstClass.DamageMeteoritesForDeflectorFirstClass * countObstacles;
                return true;
            case ObstaclesType.SpaceWhales: // TODO уничтожение корабля
                HealthPoints = 0;
                return false;
            case ObstaclesType.AntimatterFlares: // TODO Иначе смерть экипажа
                if (IsDisabledPhotonDeflector()) return false;
                HealthPointPhotonDeflector--;
                return true;

            default:
                throw new InvalidOperationException("Non-existent type of obstacle");
        }
    }
}