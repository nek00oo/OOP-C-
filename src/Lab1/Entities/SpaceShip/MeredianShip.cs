using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class MeredianShip : SpaceShipBase, ISpaceShipWithDeflector
{
    public MeredianShip(bool antineutrinoEmitter = false, bool photonDeflector = false)
        : base(antineutrinoEmitter, HullShipClass.Second, EngineType.E)
    {
        Deflector = new DeflectorSecondClass(photonDeflector);
    }

    public DeflectorBase Deflector { get; }
}