using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class VaclasShip : SpaceShipBase, ISpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public VaclasShip(double fuelGravitationalMatterQuantity, bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Second, EngineType.E)
    {
        Deflector = new DeflectorFirstClass(photonDeflector);
        FuelGravitationalMatterQuantity = fuelGravitationalMatterQuantity;
        JumpEngine = FabricCreateEngineJump.CreateJumpEngine(EngineType.Gamma);
    }

    public DeflectorBase Deflector { get; }
    public double FuelGravitationalMatterQuantity { get; private set; }
    public IJumpEngine JumpEngine { get; }

    public double UsingFuelJumpEngine(int distance)
    {
       return JumpEngine.CalculateFuelRequired(distance);
    }
}