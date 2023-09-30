using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class VaclasShip : SpaceShipBase, ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public VaclasShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Second, EngineType.E)
    {
        Deflector = new DeflectorFirstClass();
        if (photonDeflector)
            Deflector = new PhotonDeflector(Deflector);
        JumpEngine = FabricCreateEngineJump.CreateJumpEngine(EngineType.Gamma);
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
        return (HullShip.TakeDamage(obstacles, countObstacles) - residualDamage) > 0;
    }
}