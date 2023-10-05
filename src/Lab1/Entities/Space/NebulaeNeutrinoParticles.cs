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
        _countObstacles = 0;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleNebulaeNeutrinoParticles = obstacleNebulaeNeutrinoParticles;
    }

    public NebulaeNeutrinoParticles(int distance)
        : base(distance)
    {
    }

    public override NavigateRouteResult NavigateSpace(SpaceShipBase spaceShip)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
        {
            return OvercomingObstacles(spaceShip);
        }

        return new NavigateRouteResult.ShipIsLost();
    }

    public override NavigateRouteResult NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
        {
            currentPriceRoute +=
                fuelExchange.FuelCost(spaceShip.ImpulseEngine, spaceShip.UsingFuelImpulseEngine(Distance));
            return OvercomingObstacles(spaceShip);
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