using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

public abstract record NavigateSpaceResult : IRouteResult
{
    private NavigateSpaceResult() { }

    public sealed record Success(double TimeRoute, IFuelUsage FuelUsage) : NavigateSpaceResult;

    public sealed record ShipIsLost() : NavigateSpaceResult;
}