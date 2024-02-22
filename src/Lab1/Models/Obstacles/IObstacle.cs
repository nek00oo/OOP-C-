using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

public interface IObstacle
{
    public ObstacleCollisionResult InteractionWithSpaceShip(ISpaceShip spaceShip, int countObstacles);
}