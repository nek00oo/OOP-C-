using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

public class PhotonDeflector : DeflectorDecorator
{
    public PhotonDeflector(DeflectorBase deflector)
        : base(deflector)
    {
    }

    public int HealthPointPhotonDeflector { get; private set; } = 3;
    public bool IsDisabledPhotonDeflector() => HealthPointPhotonDeflector <= 0;

    public bool TakeDamagePhotonDeflector(ObstacleAntimatterFlares antimatterFlares,  int countObstacles)
    {
        if (IsDisabledPhotonDeflector())
            return false;
        HealthPointPhotonDeflector -= antimatterFlares.Damage * countObstacles;
        return HealthPointPhotonDeflector >= 0;
    }
}