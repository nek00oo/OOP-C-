using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
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
        double timeRoute = 0;
        IRouteResult navigateRouteResult;
        foreach (ISpace space in _spaceBases)
        {
            navigateRouteResult = space.NavigateSpace(spaceShip);
            if (navigateRouteResult is NavigateRouteResult.Success success)
                timeRoute += success.TimeRoute;
            if (navigateRouteResult is not NavigateRouteResult.Success)
                return navigateRouteResult;
        }

        navigateRouteResult = new NavigateRouteResult.Success(timeRoute);
        return navigateRouteResult;
    }
}