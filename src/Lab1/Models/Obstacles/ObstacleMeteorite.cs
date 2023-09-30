using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleMeteorite : IObstacleSpace
{
    public int Damage { get; } = 10;

    public bool InteractionWithSpaceShip(SpaceShipBase spaceShip, int countObstacles, ref NavigateRouteResult navigateRouteResult)
    {
        if (spaceShip.TakeDamage(this, countObstacles)) return true;

        navigateRouteResult = new NavigateRouteResult.ShipIsDestroyed();
        return false;
    }
}