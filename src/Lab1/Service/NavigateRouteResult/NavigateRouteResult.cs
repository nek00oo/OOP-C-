namespace Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

public abstract record NavigateRouteResult
{
    private NavigateRouteResult() { }
    public sealed record Success() : NavigateRouteResult;
    public sealed record CrewKilled() : NavigateRouteResult;

    public sealed record ShipIsLost() : NavigateRouteResult;

    public sealed record ShipIsDestroyed() : NavigateRouteResult;
}