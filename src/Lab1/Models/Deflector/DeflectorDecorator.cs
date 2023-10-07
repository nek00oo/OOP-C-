using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public abstract class DeflectorDecorator : IDeflector
{
    private IDeflector _wrappee;

    protected DeflectorDecorator(IDeflector deflector)
    {
        _wrappee = deflector;
        HealthPoints = _wrappee.HealthPoints;
    }

    public int HealthPoints { get; }
    public bool IsDisabled() => HealthPoints < 0;

    public DamageResult TakeDamageResult(IObstacle obstacle, int countObstacles)
    {
        return _wrappee.TakeDamageResult(obstacle, countObstacles);
    }
}