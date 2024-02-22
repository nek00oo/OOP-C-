using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeIncreasedDensitySpace : ISpace
{
    private readonly IObstacleNebulaeIncreasedDensitySpace? _obstacleNebulaeIncreasedDensitySpace;
    private readonly int _countObstacles;

    public NebulaeIncreasedDensitySpace(int distance, IObstacleNebulaeIncreasedDensitySpace obstacleNebulaeIncreasedDensitySpace, int countObstacles = 1)
    {
        if (distance < 1)
            throw new InvalidOperationException("The distance of space cannot be negative");
        Distance = distance;
        if (countObstacles < 1)
            throw new InvalidOperationException("The number of obstacles cannot be negative");
        _countObstacles = countObstacles;
        _obstacleNebulaeIncreasedDensitySpace = obstacleNebulaeIncreasedDensitySpace;
    }

    public NebulaeIncreasedDensitySpace(int distance)
    {
        if (distance < 1)
            throw new InvalidOperationException("The distance of space cannot be negative");
        Distance = distance;
    }

    public int Distance { get; }

    public IRouteResult NavigateSpace(ISpaceShip spaceShip)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.FlyingSpaceСanal(Distance) is FlyResult.SuccessFlight successFlight)
        {
            ObstacleCollisionResult resultOvercomingObstacles = OvercomingObstacles(spaceShip);
            if (resultOvercomingObstacles is ObstacleCollisionResult.Success)
                return new NavigateSpaceResult.Success(successFlight.TimeRoute, successFlight.FuelUsage);
            return resultOvercomingObstacles;
        }

        return new NavigateRouteResult.ShipIsLost();
    }

    private ObstacleCollisionResult OvercomingObstacles(ISpaceShip spaceShip)
    {
        if (_obstacleNebulaeIncreasedDensitySpace == null)
            return new ObstacleCollisionResult.Success();
        return _obstacleNebulaeIncreasedDensitySpace.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}