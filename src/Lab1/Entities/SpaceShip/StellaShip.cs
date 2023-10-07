using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public sealed class StellaShip : SpaceShipBase, IJumpEngineHolder, IDeflectorHolder
{
    public StellaShip(bool photonDeflector = false)
        : base(new HullShipFirstClass(), new ImpulseEngineC())
    {
        Deflector = new DeflectorFirstClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
        JumpEngine = new JumpEngineOmega();
    }

    public DeflectorBase Deflector { get; }
    public IJumpEngine JumpEngine { get; }

    public double UsingFuelJumpEngine(int distance)
    {
        return JumpEngine.CalculateFuelRequired(distance);
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacles,  int countObstacles)
    {
        if (Deflector.IsDisabled())
            return HullShip.TakeDamageResult(obstacles, countObstacles);
        if (Deflector.IsDisabled() is false && Deflector.TakeDamageResult(obstacles, countObstacles) is DamageResult.DamageOverflow damageOverflow)
            return HullShip.TakeDamageResult(damageOverflow.Damage);
        return new DamageResult.DamageSustained();
    }
}