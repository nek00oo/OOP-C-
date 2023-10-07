namespace Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

public abstract record NavigateRouteResult : IRouteResult
{
    private NavigateRouteResult() { }

    public sealed record Success(double TimeRoute) : NavigateRouteResult;

    public sealed record ShipIsLost() : NavigateRouteResult;
}