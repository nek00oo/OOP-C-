using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.DefinitionEffectiveShip;

public class DefinitionEffectiveShip
{
    private readonly IReadOnlyCollection<ISpaceShip> _spaceShips;
    private readonly Route _route;
    private readonly IFuelExchange _fuelExchange;

    public DefinitionEffectiveShip(IReadOnlyCollection<ISpaceShip> spaceShips, Route route, IFuelExchange fuelExchange)
    {
        _spaceShips = spaceShips;
        _route = route;
        _fuelExchange = fuelExchange;
    }

    public ISpaceShip? FindEffectiveShip()
    {
        ISpaceShip? moreEffectiveSpaceShip = null;
        double minPriceRoute = double.MaxValue;
        foreach (ISpaceShip spaceShip in _spaceShips)
        {
            if (_route.RouteResult(spaceShip) is not NavigateRouteResult.Success success) continue;
            double routePrice = _fuelExchange.FuelCost(success.FuelUsage.ToArray());
            if (!(routePrice < minPriceRoute)) continue;
            minPriceRoute = routePrice;
            moreEffectiveSpaceShip = spaceShip;
        }

        return moreEffectiveSpaceShip;
    }
}