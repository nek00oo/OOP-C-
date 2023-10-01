using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class MeredianShip : SpaceShipBase, ISpaceShipWithDeflector
{
    public MeredianShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, new HullShipSecondClass(), new ImpulseEngineE())
    {
        Deflector = new DeflectorSecondClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
    }

    public DeflectorBase Deflector { get; }
    public override bool TakeDamage(IObstaclesBase obstacles,  int countObstacles)
    {
        int residualDamage = Deflector.TakeDamage(obstacles, countObstacles);
        if (residualDamage < 0)
            return HullShip.TakeDamage(residualDamage) > 0;
        return true;
    }
}