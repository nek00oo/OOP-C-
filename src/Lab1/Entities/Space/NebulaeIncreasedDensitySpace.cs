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
    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            return OvercomingObstacles(spaceShip);
        }

        return new NavigateRouteResult.ShipIsLost();
    }

    public override NavigateRouteResult NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            currentPriceRoute += fuelExchange.FuelCost(spaceShipWithJumpEngine.JumpEngine, spaceShipWithJumpEngine.UsingFuelJumpEngine(Distance));
            return OvercomingObstacles(spaceShip);
        }

        return new NavigateRouteResult.ShipIsLost();
    }

    public override NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip)
    {
        if (_obstacleNebulaeIncreasedDensitySpace == null)
            return new NavigateRouteResult.Success();
        return _obstacleNebulaeIncreasedDensitySpace.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}