using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    private readonly IReadOnlyCollection<ISpace> _spaceBases;

    public Route(ISpace space)
    {
        _spaceBases = new List<ISpace> { space };
    }

    public Route(IReadOnlyCollection<ISpace> spaceBases)
    {
        _spaceBases = spaceBases;
    }

    public IRouteResult RouteResult(ISpaceShip spaceShip)
    {
        ICollection<IFuelUsage> fuelUsages = new List<IFuelUsage>();
        double timeRoute = 0;
        IRouteResult navigateRouteResult;
        foreach (ISpace space in _spaceBases)
        {
            navigateRouteResult = space.NavigateSpace(spaceShip);
            if (navigateRouteResult is NavigateSpaceResult.Success success)
            {
                timeRoute += success.TimeRoute;
                fuelUsages.Add(success.FuelUsage);
            }

            if (navigateRouteResult is not NavigateSpaceResult.Success)
                return navigateRouteResult;
        }

        navigateRouteResult = new NavigateRouteResult.Success(timeRoute, fuelUsages);
        return navigateRouteResult;
    }
}