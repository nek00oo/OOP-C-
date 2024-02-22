using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public interface IDeflector
{
    public int HealthPoints { get; }
    public DamageResult TakeDamageResult(int damage, int countObstacles);
}
