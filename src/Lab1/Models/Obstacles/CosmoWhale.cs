using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class CosmoWhale : IObstacleNebulaeNitrineParticles
{
    public int Damage { get; } = 100;
    public bool InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles, ref NavigateRouteResult navigateRouteResult)
    {
        if (spaceShip.AntineutrinoEmitter || spaceShip.TakeDamage(this, countObstacles))
            return true;

        navigateRouteResult = new NavigateRouteResult.ShipIsDestroyed();
        return false;
    }
}