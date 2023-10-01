using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public sealed class StellaShip : SpaceShipBase, ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public StellaShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, new HullShipFirstClass(), new ImpulseEngineC())
    {
        Deflector = new DeflectorFirstClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
        JumpEngine = new JumpEngineOmega();
    }

    public DeflectorBase Deflector { get; }
    public IJumpEngine JumpEngine { get; }

    public double UsingFuelJumpEngine(int distance)
    {
        return JumpEngine.CalculateFuelRequired(distance);
    }

    public override bool TakeDamage(IObstaclesBase obstacles,  int countObstacles)
    {
        int residualDamage = Deflector.TakeDamage(obstacles, countObstacles);
        if (residualDamage < 0)
            return HullShip.TakeDamage(residualDamage) > 0;
        return true;
    }
}