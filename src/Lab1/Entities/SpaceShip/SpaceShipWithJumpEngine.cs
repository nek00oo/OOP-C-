using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public abstract class SpaceShipWithJumpEngine : SpaceShipBase
{
    protected SpaceShipWithJumpEngine(bool antineutrinoEmitter, HullShipClass hullShipClass, EngineType engineImpulseType,  EngineType engineJumpType, double fuelPlasmQuantity, double fuelGravitationalMatterQuantity)
        : base(antineutrinoEmitter, hullShipClass, engineImpulseType,  fuelPlasmQuantity)
    {
        FuelGravitationalMatterQuantity = fuelGravitationalMatterQuantity;
        JumpEngine = FabricCreateEngineJump.CreateJumpEngine(engineJumpType);
    }

    public double FuelGravitationalMatterQuantity { get; protected set; }
    public JumpEngine JumpEngine { get; }

    public bool UsingFuelJumpEngine(int distance)
    {
        if (FuelGravitationalMatterQuantity > 0)
        {
            FuelGravitationalMatterQuantity = JumpEngine.CalculateFuelRequired(FuelGravitationalMatterQuantity, distance);
            if (FuelGravitationalMatterQuantity < 0)
                return false;
            return true;
        }

        return false;
    }
}