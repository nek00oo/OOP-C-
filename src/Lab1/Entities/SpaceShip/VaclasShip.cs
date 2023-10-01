using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public sealed class VaclasShip : SpaceShipBase, ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public VaclasShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, new HullShipSecondClass(), new ImpulseEngineE())
    {
        Deflector = new DeflectorFirstClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
        JumpEngine = new JumpEngineGamma();
    }

    public DeflectorBase Deflector { get; }
    public IJumpEngine JumpEngine { get; }

    public void UsingFuelJumpEngine(int distance)
    {
       JumpEngine.CalculateFuelRequired(distance);
    }

    public override bool TakeDamage(IObstaclesBase obstacles,  int countObstacles)
    {
        int residualDamage = Deflector.TakeDamage(obstacles, countObstacles);
        if (residualDamage < 0)
            return HullShip.TakeDamage(residualDamage) > 0;
        return true;
    }
}