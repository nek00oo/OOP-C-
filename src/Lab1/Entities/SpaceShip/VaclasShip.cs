using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class VaclasShip : ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public VaclasShip(IDeflector deflector)
    {
        Deflector = deflector;
        JumpEngine = new JumpEngineGamma();
        HullShip = new HullShipSecondClass();
        ImpulseEngine = new ImpulseEngineE();
    }

    public IImpulseEngine ImpulseEngine { get; }
    public IDeflector Deflector { get; }
    public IJumpEngine JumpEngine { get; }
    public IHullShip HullShip { get; }

    public DamageResult TakeDamageResult(IObstacle obstacles,  int countObstacles)
    {
        DamageResult deflectorDamageResult = Deflector.TakeDamageResult(obstacles, countObstacles);
        if (deflectorDamageResult is DamageResult.DamageOverflow damageOverflow)
            return HullShip.TakeDamageResult(obstacles, damageOverflow.CountObstacle);
        return deflectorDamageResult;
    }
}