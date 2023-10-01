using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class PleasureShuttle : SpaceShipBase
{
    public PleasureShuttle(bool antineutrinoEmitter = false)
        : base(antineutrinoEmitter, new HullShipFirstClass(), new ImpulseEngineC())
    {
    }

    public override bool TakeDamage(IObstaclesBase obstacles, int countObstacles)
    {
        return HullShip.TakeDamage(obstacles, countObstacles) > 0;
    }
}