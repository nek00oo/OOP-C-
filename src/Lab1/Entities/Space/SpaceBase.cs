using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public abstract class SpaceBase
{
    protected SpaceBase(int distance)
    {
        if (distance >= 0)
            Distance = distance;
    }

    public int Distance { get; }
    public abstract NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip);
    public abstract NavigateRouteResult NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute);
    public abstract NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip);
}