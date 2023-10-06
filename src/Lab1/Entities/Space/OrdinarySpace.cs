using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class OrdinarySpace : SpaceBase
{
    private readonly IObstacleSpace? _obstacleSpace;
    private readonly int _countObstacles;

    public OrdinarySpace(int distance, IObstacleSpace obstacleSpace, int countObstacles = 1)
        : base(distance)
    {
        if (countObstacles < 1)
            throw new InvalidOperationException("The number of obstacles cannot be negative");
        _countObstacles = countObstacles;
        _obstacleSpace = obstacleSpace;
    }

    public OrdinarySpace(int distance)
        : base(distance) { }

    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip, IFuelExchange fuelExchange)
    {
        double timeOvercomingSpace = Math.Round(Distance / (double)spaceShip.ImpulseEngine.Speed, 2);
        double priceOvercomingSpace =
            Math.Round(fuelExchange.FuelCost(spaceShip.ImpulseEngine, spaceShip.UsingFuelImpulseEngine(Distance)), 2);

        NavigateRouteResult resultOvercomingObstacles = OvercomingObstacles(spaceShip);
        if (resultOvercomingObstacles is NavigateRouteResult.Success)
        {
            return new NavigateRouteResult.SuccessPriceAndTimeForRoute(priceOvercomingSpace, timeOvercomingSpace);
        }

        return resultOvercomingObstacles;
    }

    public override NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip)
    {
        if (_obstacleSpace == null)
            return new NavigateRouteResult.Success();
        return _obstacleSpace.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}