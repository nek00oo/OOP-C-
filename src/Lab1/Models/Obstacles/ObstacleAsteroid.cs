using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAsteroid : IObstacleSpace
{
    private const int DamageAsteroid = 60;
    public int Damage => DamageAsteroid;

    public NavigateRouteResult InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles)
    {
        if (spaceShip.TakeDamageResult(this, countObstacles) is DamageResult.DamageSustained)
            return new NavigateRouteResult.Success();

        return new NavigateRouteResult.ShipIsDestroyed();
    }
}