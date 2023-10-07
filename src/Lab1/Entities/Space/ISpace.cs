using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public interface ISpace
{
    public int Distance { get; }
    public IRouteResult NavigateSpace(ISpaceShip spaceShip);
    public ObstacleCollisionResult OvercomingObstacles(ISpaceShip spaceShip);
}