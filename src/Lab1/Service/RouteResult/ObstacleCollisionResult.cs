namespace Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

public record ObstacleCollisionResult : IRouteResult
{
    private ObstacleCollisionResult() { }
    public sealed record ShipIsDestroyed() : ObstacleCollisionResult;
    public sealed record CrewKilled() : ObstacleCollisionResult;

    public sealed record Success() : ObstacleCollisionResult;
}