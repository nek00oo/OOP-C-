using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public interface IHullShip
{
    protected int HealthPoints { get; }
    public bool IsDestroyed();

    public DamageResult TakeDamageResult(IObstacle obstacle, int countObstacles);
}