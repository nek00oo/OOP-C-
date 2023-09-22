using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class PleasureShuttle : SpaceShipBase
{
    public PleasureShuttle(double fuelPlasmQuantity, bool antineutrinoEmitter = false)
        : base(antineutrinoEmitter, HullShipClass.First, EngineType.C, fuelPlasmQuantity)
    {
    }
}