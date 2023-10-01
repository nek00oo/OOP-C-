using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleAntimatterFlares : IObstacleNebulaeIncreasedDensitySpace
{
    public int Damage { get; } = 1;
    public int Weight { get; } = 1;

    public bool InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles, ref NavigateRouteResult navigateRouteResult)
    {
        if (countObstacles == 0 || (spaceShip is ISpaceShipWithDeflector { Deflector: PhotonDeflector deflector } && deflector.TakeDamagePhotonDeflector(this, countObstacles)))
            return true;

        navigateRouteResult = new NavigateRouteResult.CrewKilled(spaceShip);
        return false;
    }
}