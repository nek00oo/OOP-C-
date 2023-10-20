using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleMeteorite : IObstacleSpace
{
    private const int DamageMeteorite = 100;

    public ObstacleCollisionResult InteractionWithSpaceShip(ISpaceShip spaceShip, int countObstacles)
    {
        if (spaceShip.TakeDamageResult(DamageMeteorite, countObstacles) is DamageResult.DamageSustained)
            return new ObstacleCollisionResult.Success();

        return new ObstacleCollisionResult.ShipIsDestroyed();
    }
}