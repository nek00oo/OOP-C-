using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NebulaeIncreasedDensitySpace : SpaceBase
{
    public override bool OvercomingObstacles(SpaceShipBase spaceShip)
    {
        if (spaceShip is ISpaceShipWithDeflector shipWithDeflector && !shipWithDeflector.Deflector.IsDisabledPhotonDeflector())
        {
            return shipWithDeflector.Deflector.ReflectObstacles(ObstaclesType.AntimatterFlares);
        }

        return spaceShip.HullShip.ConditionAfterObstacles(ObstaclesType.AntimatterFlares);
    }

    public override bool NavigateSpace(SpaceShipBase spaceShip, int distance)
    {
        if (spaceShip is SpaceShipWithJumpEngine shipWithJumpEngine)
        {
            return shipWithJumpEngine.UsingFuelJumpEngine(distance) && OvercomingObstacles(spaceShip);
        }

        return false;
    }
}