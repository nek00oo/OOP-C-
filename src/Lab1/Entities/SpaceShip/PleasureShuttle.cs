using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class PleasureShuttle : ISpaceShip
{
    public IImpulseEngine ImpulseEngine { get; } = new ImpulseEngineC();
    public IHullShip HullShip { get; } = new HullShipFirstClass();
    public DamageResult TakeDamageResult(IObstacle obstacles, int countObstacles)
    {
        return HullShip.TakeDamageResult(obstacles, countObstacles);
    }
}