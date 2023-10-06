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

    public NavigateRouteResult RouteResult(SpaceShipBase spaceShip, IFuelExchange fuelExchange)
    {
        double priceOvercomingRoute = 0;
        double timeOvercomingRoute = 0;
        NavigateRouteResult navigateRouteResult;
        foreach (SpaceBase space in _spaceBases)
        {
            navigateRouteResult = space.NavigateSpace(spaceShip, fuelExchange);
            if (navigateRouteResult is NavigateRouteResult.SuccessPriceAndTimeForRoute successPriceRoute)
            {
                priceOvercomingRoute += successPriceRoute.PriceForRoute;
                timeOvercomingRoute += successPriceRoute.TimeRoute;
            }

            if (navigateRouteResult is not NavigateRouteResult.SuccessPriceAndTimeForRoute)
                return navigateRouteResult;
        }

        navigateRouteResult = new NavigateRouteResult.SuccessPriceAndTimeForRoute(priceOvercomingRoute, timeOvercomingRoute);
        return navigateRouteResult;
    }
}