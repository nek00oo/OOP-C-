using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public abstract class SpaceShipBase
{
    protected SpaceShipBase(bool antineutrinoEmitter, HullShipBase hullShip, IImpulseEngine impulseEngine)
    {
        AntineutrinoEmitter = antineutrinoEmitter;
        HullShip = hullShip;
        ImpulseEngine = impulseEngine;
    }

    public int FuelQuantity { get; protected set; }
    public IImpulseEngine ImpulseEngine { get; }
    public bool AntineutrinoEmitter { get; }
    protected HullShipBase HullShip { get; }

    public double UsingFuelImpulseEngine(int distance)
    {
        return ImpulseEngine.CalculateFuelRequired(distance);
    }

    public abstract bool TakeDamage(IObstaclesBase obstacles,  int countObstacles);
}