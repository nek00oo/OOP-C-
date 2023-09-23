using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public abstract class SpaceBase
{
    protected SpaceBase(int distance)
    {
        if (distance >= 0)
            Distance = distance;
    }

    public int Distance { get; }
    public abstract bool NavigateSpace(SpaceShipBase spaceShip, int distance);
    public abstract bool OvercomingObstacles(SpaceShipBase spaceShip);
}