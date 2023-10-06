using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeNeutrinoParticles : SpaceBase
{
    private const int NitroParticlesSpeedEffectAe = 2;
    private readonly IObstacleNebulaeNitrineParticles? _obstacleNebulaeNeutrinoParticles;
    private readonly int _countObstacles;

    public NebulaeNeutrinoParticles(int distance, IObstacleNebulaeNitrineParticles obstacleNebulaeNeutrinoParticles, int countObstacles = 1)
        : base(distance)
    {
        if (countObstacles < 1)
            throw new InvalidOperationException("The number of obstacles cannot be negative");
        _countObstacles = countObstacles;
        _obstacleNebulaeNeutrinoParticles = obstacleNebulaeNeutrinoParticles;
    }

    public NebulaeNeutrinoParticles(int distance)
        : base(distance) { }

    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip, IFuelExchange fuelExchange)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
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

        return new NavigateRouteResult.ShipIsLost();
    }

    public override NavigateRouteResult OvercomingObstacles(SpaceShipBase spaceShip)
    {
        if (_obstacleNebulaeNeutrinoParticles == null)
            return new NavigateRouteResult.Success();
        return _obstacleNebulaeNeutrinoParticles.InteractionWithSpaceShip(spaceShip, _countObstacles);
    }
}