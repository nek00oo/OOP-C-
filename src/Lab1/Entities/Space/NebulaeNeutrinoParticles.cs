using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeNeutrinoParticles : ISpace
{
    private readonly IObstacleNebulaeNitrineParticles? _obstacleNebulaeNeutrinoParticles;
    private readonly int _countObstacles;

    public NebulaeNeutrinoParticles(int distance, IObstacleNebulaeNitrineParticles obstacleNebulaeNeutrinoParticles, int countObstacles = 1)
    {
        if (distance < 1)
            throw new InvalidOperationException("The distance of space cannot be negative");
        Distance = distance;
        if (countObstacles < 1)
            throw new InvalidOperationException("The number of obstacles cannot be negative");
        _countObstacles = countObstacles;
        _obstacleNebulaeNeutrinoParticles = obstacleNebulaeNeutrinoParticles;
    }

    public NebulaeNeutrinoParticles(int distance)
    {
        if (distance < 1)
            throw new InvalidOperationException("The distance of space cannot be negative");
        Distance = distance;
    }

    public int NitroParticlesSpeedEffectAe { get; } = 2;
    public int Distance { get; }

    public IRouteResult NavigateSpace(ISpaceShip spaceShip)
    {
        if (spaceShip.ImpulseEngine.FlyingSpace(this) is FlyResult.SuccessFlight successFlight)
        {
            ObstacleCollisionResult resultOvercomingObstacles = OvercomingObstacles(spaceShip);
            if (resultOvercomingObstacles is ObstacleCollisionResult.Success)
                return new NavigateRouteResult.Success(successFlight.TimeRoute);
            return resultOvercomingObstacles;
        }

        return new NavigateRouteResult.ShipIsLost();
    }

    public ObstacleCollisionResult OvercomingObstacles(ISpaceShip spaceShip)
    {
        if (_obstacleNebulaeNeutrinoParticles == null)
            return new ObstacleCollisionResult.Success();
        return _obstacleNebulaeNeutrinoParticles.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}