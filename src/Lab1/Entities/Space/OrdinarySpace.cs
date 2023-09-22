using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class OrdinarySpace : SpaceBase
{
    public override bool NavigateSpace(SpaceShipBase spaceShip, int distance) =>
        spaceShip.UsingFuelImpulseEngine(distance) && OvercomingObstacles(spaceShip);

    public override bool OvercomingObstacles(SpaceShipBase spaceShip) // TODO метеорит
    {
        if (spaceShip is ISpaceShipWithDeflector shipWithDeflector)
        {
            return shipWithDeflector.Deflector.ReflectObstacles(ObstaclesType.Asteroid);
        }

        return spaceShip.HullShip.ConditionAfterObstacles(ObstaclesType.Asteroid);
    }
}