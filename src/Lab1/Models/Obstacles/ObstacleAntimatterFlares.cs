using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAntimatterFlares : IObstacleNebulaeIncreasedDensitySpace
{
    public int Damage { get; } = 1;

    public NavigateRouteResult InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles)
    {
        if (countObstacles == 0 || (spaceShip is ISpaceShipWithDeflector { Deflector: PhotonDeflector deflector } && deflector.TakeDamagePhotonDeflector(this, countObstacles)))
            return new NavigateRouteResult.Success();

        return new NavigateRouteResult.CrewKilled();
    }
}