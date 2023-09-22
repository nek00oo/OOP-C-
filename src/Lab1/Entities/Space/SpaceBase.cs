using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public abstract class SpaceBase
{
    public abstract bool NavigateSpace(SpaceShipBase spaceShip,  int distance);
    public abstract bool OvercomingObstacles(SpaceShipBase spaceShip);
}