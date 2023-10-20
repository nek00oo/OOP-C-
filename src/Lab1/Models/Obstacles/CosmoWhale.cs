using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class CosmoWhale : IObstacleNebulaeNitrineParticles
{
    private const int DamageCosmoWhale = 300;

    public ObstacleCollisionResult InteractionWithSpaceShip(ISpaceShip spaceShip,  int countObstacles)
    {
        if (spaceShip is ISpaceShipWithAntineutrinoEmitter ||
            spaceShip.TakeDamageResult(DamageCosmoWhale, countObstacles) is DamageResult.DamageSustained)
            return new ObstacleCollisionResult.Success();

        return new ObstacleCollisionResult.ShipIsDestroyed();
    }
}