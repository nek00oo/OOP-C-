using System;
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
        if (countObstacles < 1)
            throw new InvalidOperationException("The number of obstacles cannot be negative");
        _countObstacles = countObstacles;
        _obstacleNebulaeIncreasedDensitySpace = obstacleNebulaeIncreasedDensitySpace;
    }

    public NebulaeIncreasedDensitySpace(int distance)
        : base(distance)
    {
    }

    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip, IFuelExchange fuelExchange)
    {
        if (spaceShip is IJumpEngineHolder spaceShipWithJumpEngine &&
            spaceShipWithJumpEngine.JumpEngine.JumpRange >= Distance)
        {
            const double timeOvercomingSpace = 1;
            double priceOvercomingSpace =
                Math.Round(fuelExchange.FuelCost(spaceShipWithJumpEngine.JumpEngine, spaceShipWithJumpEngine.UsingFuelJumpEngine(Distance)), 2);

            NavigateRouteResult resultOvercomingObstacles = OvercomingObstacles(spaceShip);
            if (resultOvercomingObstacles is NavigateRouteResult.Success)
            {
                return new NavigateRouteResult.SuccessPriceAndTimeForRoute(priceOvercomingSpace, timeOvercomingSpace);
            }

            return resultOvercomingObstacles;
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