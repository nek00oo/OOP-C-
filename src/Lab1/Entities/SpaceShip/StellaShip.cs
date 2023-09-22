using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class StellaShip : SpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public StellaShip(double fuelPlasmQuantity, double fuelGravitationalMatterQuantity, bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.First, EngineType.C, EngineType.Omega, fuelPlasmQuantity, fuelGravitationalMatterQuantity)
    {
        Deflector = new DeflectorFirstClass(photonDeflector);
    }

    public DeflectorBase Deflector { get; }
}