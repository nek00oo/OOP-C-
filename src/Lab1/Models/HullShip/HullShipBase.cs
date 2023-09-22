using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public abstract class HullShipBase
{
    protected HullShipBase(HullShipClass hullShipClass)
    {
        HullShipClass = hullShipClass;
        HealthPoint = 100 + 1;
    }

    public HullShipClass HullShipClass { get; protected set; }
    protected int HealthPoint { get; set; }
    public bool IsDestroyed() => HealthPoint <= 0;

    public abstract bool ConditionAfterObstacles(ObstaclesType obstaclesType);
}