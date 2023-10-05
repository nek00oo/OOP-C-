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

    public override bool NavigateSpace(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        return OvercomingObstacles(spaceShip, ref navigateRouteResult);
    }

    public override bool NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        currentPriceRoute += fuelExchange.FuelCost(spaceShip.ImpulseEngine, spaceShip.UsingFuelImpulseEngine(Distance));
        return true;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        if (_obstacleSpace == null)
            return true;
        return _obstacleSpace.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}