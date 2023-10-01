using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class AvgureShip : SpaceShipBase, ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public AvgureShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, new HullShipThirdClass(), new ImpulseEngineE())
    {
        Deflector = new DeflectorThirdClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
        JumpEngine = new JumpEngineAlpha();
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