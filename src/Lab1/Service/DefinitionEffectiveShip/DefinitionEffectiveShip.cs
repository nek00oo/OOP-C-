using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.DefinitionEffectiveShip;

public class DefinitionEffectiveShip : ICanFindEffectiveShip
{
    private readonly IReadOnlyCollection<SpaceShipBase> _spaceShips;
    private readonly Route _route;
    private readonly IFuelExchange _fuelExchange;

    public DefinitionEffectiveShip(IReadOnlyCollection<SpaceShipBase> spaceShips, Route route, IFuelExchange fuelExchange)
    {
        _spaceShips = spaceShips;
        _route = route;
        _fuelExchange = fuelExchange;
    }

    public SpaceShipBase? FindEffectiveShip()
    {
        SpaceShipBase? moreEffectiveSpaceShip = null;
        double minPriceRoute = double.MaxValue;
        foreach (SpaceShipBase spaceShip in _spaceShips)
        {
            if (_route.RouteResult(spaceShip, _fuelExchange) is NavigateRouteResult.NavigateRouteResult.SuccessPriceAndTimeForRoute successPriceRoute
                && successPriceRoute.PriceForRoute < minPriceRoute)
            {
                minPriceRoute = successPriceRoute.PriceForRoute;
                moreEffectiveSpaceShip = spaceShip;
            }
        }

        return moreEffectiveSpaceShip;
    }
}