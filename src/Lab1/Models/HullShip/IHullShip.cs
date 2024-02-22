using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public interface IHullShip
{
    public DamageResult TakeDamageResult(int damage, int countObstacles);
}