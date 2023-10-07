using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class MeredianShip : SpaceShipBase, IDeflectorHolder, IAntineutrinoEmitterHolder
{
    public MeredianShip(bool photonDeflector = false)
        : base(new HullShipSecondClass(), new ImpulseEngineE())
    {
        Deflector = new DeflectorSecondClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
    }

    public DeflectorBase Deflector { get; }
    public bool AntineutrinoEmitter { get; } = true;
    public override DamageResult TakeDamageResult(IObstaclesBase obstacles,  int countObstacles)
    {
        if (Deflector.IsDisabled())
            return HullShip.TakeDamageResult(obstacles, countObstacles);
        if (Deflector.IsDisabled() is false && Deflector.TakeDamageResult(obstacles, countObstacles) is DamageResult.DamageOverflow damageOverflow)
            return HullShip.TakeDamageResult(damageOverflow.Damage);
        return new DamageResult.DamageSustained();
    }
}