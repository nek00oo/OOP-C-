using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public abstract class SpaceBase
{
    protected SpaceBase(int distance)
    {
        if (distance < 1)
            throw new InvalidOperationException("The distance of space cannot be negative");
        Distance = distance;
    }

    public int Distance { get; }
    public abstract NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip, IFuelExchange fuelExchange);
    public abstract NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip);
}