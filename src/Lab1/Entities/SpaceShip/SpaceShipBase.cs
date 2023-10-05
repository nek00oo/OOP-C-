using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public abstract class SpaceShipBase
{
    protected SpaceShipBase(HullShipBase hullShip, IImpulseEngine impulseEngine)
    {
        HullShip = hullShip;
        ImpulseEngine = impulseEngine;
    }

    public IImpulseEngine ImpulseEngine { get; }
    protected HullShipBase HullShip { get; }

    public double UsingFuelImpulseEngine(int distance)
    {
        return ImpulseEngine.CalculateFuelRequired(distance);
    }

    public abstract DamageResult TakeDamageResult(IObstaclesBase obstacles, int countObstacles);
}