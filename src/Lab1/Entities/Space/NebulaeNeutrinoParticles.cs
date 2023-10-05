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

    public override bool NavigateSpace(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
        {
            return OvercomingObstacles(spaceShip, ref navigateRouteResult);
        }

        navigateRouteResult = new NavigateRouteResult.ShipIsLost();
        return false;
    }

    public override bool NavigateSpacePrice(SpaceShipBase spaceShip, IFuelExchange fuelExchange, ref double currentPriceRoute)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
        {
            currentPriceRoute +=
                fuelExchange.FuelCost(spaceShip.ImpulseEngine, spaceShip.UsingFuelImpulseEngine(Distance));
            return true;
        }

        return false;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        if (_obstacleNebulaeNeutrinoParticles == null)
            return true;
        return _obstacleNebulaeNeutrinoParticles.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}