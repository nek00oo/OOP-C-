using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public interface IPhotonDeflector
{
    public DamageResult TakePhotonicDamage(int damage, int countObstacles);
}