using System;

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

    public double FuelCost(IFuelUsage fuelType, double fuelQuantity)
    {
        return fuelType switch
        {
            IFuelUsageActivePlasma => fuelQuantity * ActivePlasmaPriceFuel,
            IFuelUsageGravitonMatter => fuelQuantity * GravitationalMatterPriceFuel,
            _ => throw new InvalidOperationException("indefinite type of fuel"),
        };
    }
}