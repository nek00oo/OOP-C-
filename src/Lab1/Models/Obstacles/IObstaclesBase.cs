using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public interface IObstaclesBase
{
    public int Damage { get; }

    public bool InteractionWithSpaceShip(SpaceShipBase spaceShip, int countObstacles, ref NavigateRouteResult navigateRouteResult);
}