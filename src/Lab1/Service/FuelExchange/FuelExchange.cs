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

    public double FuelCost(IFuelUsage fuelType)
    {
        return fuelType switch
        {
            IFuelUsageActivePlasma => fuelType.FuelQuantity * ActivePlasmaPriceFuel,
            IFuelUsageGravitonMatter => fuelType.FuelQuantity * GravitationalMatterPriceFuel,
            _ => throw new InvalidOperationException("indefinite type of fuel"),
        };
    }
}