using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeNitrineParticles : SpaceBase
{
    private readonly IObstacleNebulaeNitrineParticles _obstacleNebulaeNitrineParticles;
    private readonly int _countObstacles;

    public NebulaeNitrineParticles(int distance, IObstacleNebulaeNitrineParticles obstacleNebulaeNitrineParticles, int countObstacles = 0)
        : base(distance)
    {
        _countObstacles = countObstacles;
        _obstacleNebulaeNitrineParticles = obstacleNebulaeNitrineParticles;
    }

    public override bool NavigateSpace(SpaceShipBase spaceShip, out NavigateRouteResult navigateRouteResult)
    {
        if (spaceShip.ImpulseEngine is ImpulseEngineE)
        {
           navigateRouteResult = new NavigateRouteResult.Success(spaceShip.UsingFuelImpulseEngine(Distance));
           return OvercomingObstacles(spaceShip, ref navigateRouteResult);
        }

        navigateRouteResult = new NavigateRouteResult.ShipIsLost();
        return false;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        return _obstacleNebulaeNitrineParticles.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}