using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public class CosmoWhale : IObstacleNebulaeNitrineParticles
{
    private const int DamageCosmoWhale = 300;
    public int Damage => DamageCosmoWhale;

    public NavigateRouteResult InteractionWithSpaceShip(SpaceShipBase spaceShip,  int countObstacles)
    {
        if (spaceShip is IHaveAntineutrinoEmitter || spaceShip.TakeDamageResult(this, countObstacles) is DamageResult.DamageSustained)
            return new NavigateRouteResult.Success();

        return new NavigateRouteResult.ShipIsDestroyed();
    }
}