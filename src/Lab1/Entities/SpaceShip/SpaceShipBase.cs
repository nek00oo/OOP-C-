using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public abstract class SpaceShipBase
{
    protected SpaceShipBase(bool antineutrinoEmitter, HullShipClass hullShipClass, EngineType engineImpulseType)
    {
        AntineutrinoEmitter = antineutrinoEmitter;
        ImpulseEngine = FabricCreateEngineImpulse.CreateEngine(engineImpulseType);
        HullShip = FabricCreateHullShip.CreateHullShip(hullShipClass);
    }

    public IImpulseEngine ImpulseEngine { get; }
    public bool AntineutrinoEmitter { get; protected set; }
    public HullShipBase HullShip { get; protected set; }

    public double UsingFuelImpulseEngine(int distance)
    {
        return ImpulseEngine.CalculateFuelRequired(distance);
    }
}