using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorBase
{
    public abstract int HealthPoints { get; protected set; }
    public bool IsDisabled() => HealthPoints <= 0;

    public abstract DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles);
}
