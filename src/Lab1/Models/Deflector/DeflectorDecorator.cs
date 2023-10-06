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

    public sealed override int HealthPoints { get; protected set; }
    private DeflectorBase Wrappee { get; }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        return Wrappee.TakeDamageResult(obstacle, countObstacles);
    }
}