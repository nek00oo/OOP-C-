using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.TransferDamage;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    public PhotonDeflector(DeflectorBase deflector)
        : base(deflector)
    {
    }

    public int HealthPointPhotonDeflector { get; private set; } = 3;
    public bool IsDisabledPhotonDeflector() => HealthPointPhotonDeflector <= 0;

    public bool TakeDamagePhotonDeflector(ObstacleAntimatterFlares antimatterFlares, int countObstacles)
    {
        if (IsDisabledPhotonDeflector())
            return false;
        HealthPointPhotonDeflector -= antimatterFlares.Damage * countObstacles;
        return HealthPointPhotonDeflector >= 0;
    }

    public override DamageResult TakeDamageResult(IObstaclesBase obstacle, int countObstacles)
    {
        HealthPoints -= obstacle.Damage * countObstacles;
        if (IsDisabled())
            return new DamageResult.DamageOverflow(Math.Abs(HealthPoints));
        return new DamageResult.DamageSustained();
    }
}