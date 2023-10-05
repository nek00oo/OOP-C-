using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class PleasureShuttle : SpaceShipBase
{
    public PleasureShuttle()
        : base(new HullShipFirstClass(), new ImpulseEngineC())
    {
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacles, int countObstacles)
    {
        return HullShip.TakeDamageResult(obstacles, countObstacles);
    }
}