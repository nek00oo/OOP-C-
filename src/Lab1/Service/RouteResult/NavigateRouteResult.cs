using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

public abstract record NavigateRouteResult : IRouteResult
{
    private NavigateRouteResult() { }

    public sealed record Success(double TimeRoute, ICollection<IFuelUsage> FuelUsage) : NavigateRouteResult;

    public sealed record ShipIsLost() : NavigateRouteResult;
}