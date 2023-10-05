using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class ObstacleMeteorite : IObstacleSpace
{
    public int Damage { get; } = 100;

    public bool InteractionWithSpaceShip(SpaceShipBase spaceShip, int countObstacles, ref NavigateRouteResult navigateRouteResult)
    {
        if (spaceShip.TakeDamageResult(this, countObstacles) is DamageResult.DamageSustained)
            return true;

        navigateRouteResult = new NavigateRouteResult.ShipIsDestroyed();
        return false;
    }
}