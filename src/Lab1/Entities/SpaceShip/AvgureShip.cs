using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class AvgureShip : ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public AvgureShip(IDeflector deflector)
    {
        Deflector = deflector;
        JumpEngine = new JumpEngineAlpha();
        HullShip = new HullShipThirdClass();
        ImpulseEngine = new ImpulseEngineE();
    }

    public IImpulseEngine ImpulseEngine { get; }
    public IDeflector Deflector { get; }
    public IJumpEngine JumpEngine { get; }
    public IHullShip HullShip { get; }
    public DamageResult TakeDamageResult(int damage,  int countObstacles)
    {
        DamageResult deflectorDamageResult = Deflector.TakeDamageResult(damage, countObstacles);
        if (deflectorDamageResult is DamageResult.DamageOverflow damageOverflow)
            return HullShip.TakeDamageResult(damage, damageOverflow.CountObstacle);
        return deflectorDamageResult;
    }
}