using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAntimatterFlares : IObstacleNebulaeIncreasedDensitySpace
{
    private const int DamageAntimatterFlares = 1;
    public int Damage => DamageAntimatterFlares;

    public ObstacleCollisionResult InteractionWithSpaceShip(ISpaceShip spaceShip,  int countObstacles)
    {
        if (countObstacles == 0 || (spaceShip is ISpaceShipWithDeflector { Deflector: IPhotonDeflector deflector } &&
                                    deflector.TakeDamagePhotonDeflector(this, countObstacles)))
            return new ObstacleCollisionResult.Success();

        return new ObstacleCollisionResult.CrewKilled();
    }
}