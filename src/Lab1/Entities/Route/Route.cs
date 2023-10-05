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
            navigateRouteResult = space.NavigateSpace(spaceShip);
            if (navigateRouteResult is not NavigateRouteResult.Success)
                return navigateRouteResult;
        }

        return navigateRouteResult;
    }

    public NavigateRouteResult PriceRoute(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        NavigateRouteResult navigateRouteResult = new NavigateRouteResult.Success();
        foreach (SpaceBase space in _spaceBases)
        {
            navigateRouteResult = space.NavigateSpacePrice(spaceShip, fuelExchange, ref currentPriceRoute);
            if (navigateRouteResult is not NavigateRouteResult.Success)
                return navigateRouteResult;
        }

        return navigateRouteResult;
    }
}