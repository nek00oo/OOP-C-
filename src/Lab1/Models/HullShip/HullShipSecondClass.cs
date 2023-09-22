using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    public HullShipSecondClass()
        : base(HullShipClass.Second)
    {
        HealthPoint = (ConstClass.DamageAsteroidsForHullSecondClass *
                       ConstClass.DamageMeteoritesForHullSecondClass) + 1;
    }

    public override bool ConditionAfterObstacles(ObstaclesType obstaclesType)
    {
        if (IsDestroyed()) return false;
        switch (obstaclesType)
        {
            case ObstaclesType.Asteroid:
                HealthPoint -= ConstClass.DamageAsteroidsForHullSecondClass;
                return true;
            case ObstaclesType.Meteorite: // TODO Уничтожение корабля
                HealthPoint -= ConstClass.DamageMeteoritesForHullSecondClass;
                return true;
            case ObstaclesType.AntimatterFlares:
                HealthPoint = 0;
                return false;
            case ObstaclesType.SpaceWhales: // TODO Уничтожение корабля
                HealthPoint = 0;
                return false;
            default:
                throw new InvalidOperationException("Non-existent type of obstacle");
        }
    }
}