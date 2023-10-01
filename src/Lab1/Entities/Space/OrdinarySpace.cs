using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class OrdinarySpace : SpaceBase
{
    private readonly IObstacleSpace _obstacleSpace;
    private readonly int _countObstacles;

    public OrdinarySpace(int distance, IObstacleSpace obstacleSpace, int countObstacles = 0)
        : base(distance)
    {
        _countObstacles = 0;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleSpace = obstacleSpace;
    }

    public override bool NavigateSpace(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        spaceShip.UsingFuelImpulseEngine(Distance);
        return OvercomingObstacles(spaceShip, ref navigateRouteResult);
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        return _obstacleSpace.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}