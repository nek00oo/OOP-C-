using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAntimatterFlares : IObstacleNebulaeIncreasedDensitySpace
{
    private const int DamageAntimatterFlares = 1;

    public ObstacleCollisionResult InteractionWithSpaceShip(ISpaceShip spaceShip,  int countObstacles)
    {
        if (spaceShip is ISpaceShipWithDeflector { Deflector: IPhotonDeflector deflector } &&
            deflector.TakePhotonicDamage(DamageAntimatterFlares, countObstacles) is DamageResult.DamageSustained)
            return new ObstacleCollisionResult.Success();

        return new ObstacleCollisionResult.CrewKilled();
    }
}