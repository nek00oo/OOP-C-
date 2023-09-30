using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class MeredianShip : SpaceShipBase, ISpaceShipWithDeflector
{
    public MeredianShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Second, EngineType.E)
    {
        Deflector = new DeflectorSecondClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
    }

    public DeflectorBase Deflector { get; }
    public override bool TakeDamage(IObstaclesBase obstacles,  int countObstacles)
    {
        int residualDamage = Deflector.TakeDamage(obstacles, countObstacles);
        return (HullShip.TakeDamage(obstacles, countObstacles) - residualDamage) > 0;
    }
}