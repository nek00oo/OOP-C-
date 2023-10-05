using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public class DefinitionEffectiveShip
{
    private readonly IReadOnlyCollection<SpaceShipBase> _spaceShips;
    private readonly Route _route;
    private IFuelExchange _fuelExchange;

    public DefinitionEffectiveShip(IReadOnlyCollection<SpaceShipBase> spaceShips, Route route, IFuelExchange fuelExchange)
    {
        _spaceShips = spaceShips;
        _route = route;
        _fuelExchange = fuelExchange;
    }

    public void ChangeExchange(IFuelExchange fuelExchange) => _fuelExchange = fuelExchange;

    public SpaceShipBase? FindEffectiveShip()
    {
        SpaceShipBase? moreEffectiveSpaceShip = null;
        double minPriceRoute = double.MaxValue;
        foreach (SpaceShipBase spaceShip in _spaceShips)
        {
            double currentPriceRoute = 0;
            if (_route.PriceRoute(spaceShip, _fuelExchange, ref currentPriceRoute) is NavigateRouteResult.NavigateRouteResult.Success && currentPriceRoute < minPriceRoute)
            {
                minPriceRoute = currentPriceRoute;
                moreEffectiveSpaceShip = spaceShip;
            }
        }

        return moreEffectiveSpaceShip;
    }
}