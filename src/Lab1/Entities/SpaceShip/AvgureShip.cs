using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class AvgureShip : SpaceShipWithJumpEngine, ISpaceShipWithDeflector
{
    public AvgureShip(double fuelPlasmQuantity, double fuelGravitationalMatterQuantity, bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Third, EngineType.E, EngineType.Alpha, fuelPlasmQuantity, fuelGravitationalMatterQuantity)
    {
        Deflector = new DeflectorThirdClass(photonDeflector);
    }

    public DeflectorBase Deflector { get; }
}