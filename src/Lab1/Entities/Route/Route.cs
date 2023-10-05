using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    private readonly IReadOnlyCollection<SpaceBase> _spaceBases;

    public Route(SpaceBase space)
    {
        _spaceBases = new List<SpaceBase> { space };
    }

    public Route(IReadOnlyCollection<SpaceBase> spaceBases)
    {
        _spaceBases = spaceBases;
    }

    public NavigateRouteResult RouteResult(SpaceShipBase spaceShip)
    {
        NavigateRouteResult navigateRouteResult = new NavigateRouteResult.Success();
        foreach (SpaceBase space in _spaceBases)
        {
            if (space.NavigateSpace(spaceShip, ref navigateRouteResult) is false)
                break;
            navigateRouteResult = new NavigateRouteResult.Success();
        }

        return navigateRouteResult;
    }

    public NavigateRouteResult PriceRoute(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        foreach (SpaceBase space in _spaceBases)
        {
            if (space.NavigateSpacePrice(spaceShip, fuelExchange, ref currentPriceRoute) is false)
                return new NavigateRouteResult.ShipIsLost();
        }

        return new NavigateRouteResult.Success();
    }
}