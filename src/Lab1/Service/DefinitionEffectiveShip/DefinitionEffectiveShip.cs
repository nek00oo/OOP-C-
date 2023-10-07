using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.DefinitionEffectiveShip;

public class DefinitionEffectiveShip : IFindEffectiveShip
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
            if (_route.RouteResult(spaceShip) is NavigateRouteResult.Success)
            {
                double routePrice = 0;
                if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine)
                    routePrice = _fuelExchange.FuelCost(spaceShip.ImpulseEngine) + _fuelExchange.FuelCost(spaceShipWithJumpEngine.JumpEngine);
                else
                    routePrice = _fuelExchange.FuelCost(spaceShip.ImpulseEngine);

                if (routePrice < minPriceRoute)
                {
                    minPriceRoute = routePrice;
                    moreEffectiveSpaceShip = spaceShip;
                }
            }
        }

        return moreEffectiveSpaceShip;
    }
}