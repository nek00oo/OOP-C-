using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAntimatterFlares : IObstacleNebulaeIncreasedDensitySpace
{
    private const int DamageAntimatterFlares = 1;
    public int Damage => DamageAntimatterFlares;

    public NavigateRouteResult InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles)
    {
        if (countObstacles == 0 || (spaceShip is IHaveDeflector { Deflector: PhotonDeflector deflector } && deflector.TakeDamagePhotonDeflector(this, countObstacles)))
            return new NavigateRouteResult.Success();

        return new NavigateRouteResult.CrewKilled();
    }
}