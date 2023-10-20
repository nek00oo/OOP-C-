using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface ISpaceShip
{
    public IImpulseEngine ImpulseEngine { get; }
    public IHullShip HullShip { get; }
    public DamageResult TakeDamageResult(int damage, int countObstacles);
}