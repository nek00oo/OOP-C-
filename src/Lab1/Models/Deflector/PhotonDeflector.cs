using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class PhotonDeflector : DeflectorDecorator, IPhotonDeflector
{
    private const int HpPhotonDeflector = 3;
    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    public int HealthPointPhotonDeflector { get; private set; } = HpPhotonDeflector;
    public bool IsDisabledPhotonDeflector() => HealthPointPhotonDeflector <= 0;

    public DamageResult TakePhotonicDamage(int damage, int countObstacles)
    {
        if (IsDisabledPhotonDeflector())
            return new DamageResult.Destroyed();
        HealthPointPhotonDeflector -= damage * countObstacles;

        return new DamageResult.DamageSustained();
    }
}