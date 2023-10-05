using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorDecorator : DeflectorBase
{
    protected DeflectorDecorator(DeflectorBase deflector)
    {
        Wrappee = deflector;
        HealthPoints = Wrappee.HealthPoints;
    }

    public DeflectorBase Wrappee { get; protected set; }

    public sealed override int HealthPoints { get; protected set; }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        return Wrappee.TakeDamageResult(obstacle, countObstacles);
    }
}