using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeIncreasedDensitySpace : SpaceBase
{
    private readonly IObstacleNebulaeIncreasedDensitySpace _obstacleNebulaeIncreasedDensitySpace;
    private readonly int _countObstacles;

    public NebulaeIncreasedDensitySpace(int distance, IObstacleNebulaeIncreasedDensitySpace obstacleNebulaeIncreasedDensitySpace, int countObstacles = 0)
        : base(distance)
    {
        _countObstacles = 0;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleNebulaeIncreasedDensitySpace = obstacleNebulaeIncreasedDensitySpace;
    }

    public override bool NavigateSpace(SpaceShipBase spaceShip,  out NavigateRouteResult navigateRouteResult, ref double fuelQuantity)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            fuelQuantity += spaceShipWithJumpEngine.UsingFuelJumpEngine(Distance);
            navigateRouteResult =
                new NavigateRouteResult.Success(spaceShip, fuelQuantity);
            return OvercomingObstacles(spaceShip, ref navigateRouteResult);
        }

        navigateRouteResult = new NavigateRouteResult.ShipIsLost(spaceShip);
        return false;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        return _obstacleNebulaeIncreasedDensitySpace.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}