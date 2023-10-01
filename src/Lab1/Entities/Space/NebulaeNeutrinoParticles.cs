using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeNeutrinoParticles : SpaceBase
{
    private const int NitroParticlesSpeedEffectAe = 2;
    private readonly IObstacleNebulaeNitrineParticles _obstacleNebulaeNeutrinoParticles;
    private readonly int _countObstacles;

    public NebulaeNeutrinoParticles(int distance, IObstacleNebulaeNitrineParticles obstacleNebulaeNeutrinoParticles, int countObstacles = 0)
        : base(distance)
    {
        _countObstacles = 0;
        if (countObstacles > 0)
            _countObstacles = countObstacles;
        _obstacleNebulaeNeutrinoParticles = obstacleNebulaeNeutrinoParticles;
    }

    public override bool NavigateSpace(SpaceShipBase spaceShip, out NavigateRouteResult navigateRouteResult, ref double fuelQuantity)
    {
        spaceShip.ImpulseEngine.SlowingSpeed(NitroParticlesSpeedEffectAe, Distance);
        if (spaceShip.ImpulseEngine.Speed > 0)
        {
            fuelQuantity += spaceShip.UsingFuelImpulseEngine(Distance);
            navigateRouteResult = new NavigateRouteResult.Success(spaceShip, fuelQuantity);
            return OvercomingObstacles(spaceShip, ref navigateRouteResult);
        }

        navigateRouteResult = new NavigateRouteResult.ShipIsLost(spaceShip);
        return false;
    }

    public override bool OvercomingObstacles(SpaceShipBase spaceShip, ref NavigateRouteResult navigateRouteResult)
    {
        return _obstacleNebulaeNeutrinoParticles.InteractionWithSpaceShip(spaceShip, _countObstacles, ref navigateRouteResult);
    }
}