using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public class FuelExchange : IFuelExchange
{
    public FuelExchange(double activePlasmaFuelAe, double gravitationalMatterFuelAe)
    {
        ActivePlasmaPriceFuel = activePlasmaFuelAe;
        GravitationalMatterPriceFuel = gravitationalMatterFuelAe;
    }

    public double ActivePlasmaPriceFuel { get; }
    public double GravitationalMatterPriceFuel { get; }

    public double FuelCost(IReadOnlyCollection<IFuelUsage> fuelType)
    {
        return fuelType.Sum(fuel => fuel switch
        {
            IUsageFuelActivePlasma => fuel.FuelQuantity * ActivePlasmaPriceFuel,
            IUsageFuelGravitonMatter => fuel.FuelQuantity * GravitationalMatterPriceFuel,
            _ => throw new InvalidOperationException("indefinite type of fuel"),
        });
    }
}