using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public abstract class SpaceShipBase
{
    protected SpaceShipBase(bool antineutrinoEmitter, HullShipClass hullShipClass, EngineType engineImpulseType,  double fuelPlasmQuantity)
    {
        AntineutrinoEmitter = antineutrinoEmitter;
        ImpulseEngine = FabricCreateEngineImpulse.CreateEngine(engineImpulseType);
        FuelPlasmQuantity = fuelPlasmQuantity;
        HullShip = FabricCreateHullShip.CreateHullShip(hullShipClass);
    }

    public ImpulseEngine ImpulseEngine { get; }
    public bool AntineutrinoEmitter { get; protected set; }
    public double FuelPlasmQuantity { get; protected set; }

    public HullShipBase HullShip { get; protected set; }

    public bool UsingFuelImpulseEngine(int distance)
    {
        if (FuelPlasmQuantity <= 0) return false;
        FuelPlasmQuantity = ImpulseEngine.CalculateFuelRequired(FuelPlasmQuantity, distance);
        return FuelPlasmQuantity > 0;
    }
}