using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeIncreasedDensitySpace : SpaceBase
{
    private readonly IObstacleNebulaeIncreasedDensitySpace? _obstacleNebulaeIncreasedDensitySpace;
    private readonly int _countObstacles;

    public NebulaeIncreasedDensitySpace(int distance, IObstacleNebulaeIncreasedDensitySpace obstacleNebulaeIncreasedDensitySpace, int countObstacles = 1)
        : base(distance)
    {
        _countObstacles = 1;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleNebulaeIncreasedDensitySpace = obstacleNebulaeIncreasedDensitySpace;
    }

    public NebulaeIncreasedDensitySpace(int distance)
        : base(distance) { }
    public override bool NavigateSpace(SpaceShipBase spaceShip,  ref NavigateRouteResult navigateRouteResult)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            return OvercomingObstacles(spaceShip, ref navigateRouteResult);
        }

        navigateRouteResult = new NavigateRouteResult.ShipIsLost();
        return false;
    }

    public override bool NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            currentPriceRoute += fuelExchange.FuelCost(spaceShipWithJumpEngine.JumpEngine, spaceShipWithJumpEngine.UsingFuelJumpEngine(Distance));
            return true;
        }

        return false;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        if (_obstacleNebulaeIncreasedDensitySpace == null)
            return true;
        return _obstacleNebulaeIncreasedDensitySpace.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}