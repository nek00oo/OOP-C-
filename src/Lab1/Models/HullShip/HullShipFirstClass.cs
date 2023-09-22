using System;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipFirstClass : HullShipBase
{
    public HullShipFirstClass()
        : base(HullShipClass.First)
    {
        HealthPoint = ConstClass.DamageAsteroidsForHullFirstClass + 1;
    }

    public override bool ConditionAfterObstacles(ObstaclesType obstaclesType)
    {
        if (IsDestroyed()) return false;
        switch (obstaclesType)
        {
            case ObstaclesType.Asteroid:
                HealthPoint -= ConstClass.DamageAsteroidsForHullFirstClass;
                return true;
            case ObstaclesType.Meteorite: // TODO Уничтожение корабля
                HealthPoint = 0;
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