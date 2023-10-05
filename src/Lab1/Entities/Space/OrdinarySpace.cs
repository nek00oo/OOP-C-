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
        _countObstacles = 0;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleSpace = obstacleSpace;
    }

    public OrdinarySpace(int distance)
        : base(distance) { }

    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip)
    {
        return OvercomingObstacles(spaceShip);
    }

    public override NavigateRouteResult NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        currentPriceRoute += fuelExchange.FuelCost(spaceShip.ImpulseEngine, spaceShip.UsingFuelImpulseEngine(Distance));
        return OvercomingObstacles(spaceShip);
    }

    public override NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip)
    {
        if (_obstacleSpace == null)
            return new NavigateRouteResult.Success();
        return _obstacleSpace.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}