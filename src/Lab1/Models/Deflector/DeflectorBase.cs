using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorBase
{
    protected int HealthPoints { get; set; }
    public bool IsDisabled() => HealthPoints <= 0;

    public abstract DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles);
}
