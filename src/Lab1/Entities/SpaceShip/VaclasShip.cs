using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class VaclasShip : SpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public VaclasShip(double fuelPlasmQuantity, double fuelGravitationalMatterQuantity, bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Second, EngineType.E, EngineType.Gamma, fuelPlasmQuantity, fuelGravitationalMatterQuantity)
    {
        Deflector = new DeflectorFirstClass(photonDeflector);
    }

    public DeflectorBase Deflector { get; }
}