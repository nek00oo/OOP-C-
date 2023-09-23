using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public abstract class HullShipBase
{
    protected HullShipBase(HullShipClass hullShipClass)
    {
        HullShipClass = hullShipClass;
        HealthPoints = 100 + 1;
    }

    public HullShipClass HullShipClass { get; protected set; }
    protected int HealthPoints { get; set; }
    public bool IsDestroyed() => HealthPoints <= 0;

    public bool TakeDamage(IObstaclesBase obstacle, int count = 1)
    {
        HealthPoints -= obstacle.Damage * count;
        return HealthPoints > 0;
    }
}