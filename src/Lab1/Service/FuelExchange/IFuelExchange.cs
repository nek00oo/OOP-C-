using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public interface IFuelExchange
{
    public double ActivePlasmaPriceFuel { get; }
    public double GravitationalMatterPriceFuel { get; }
    public double FuelCost(IReadOnlyCollection<IFuelUsage> fuelType);
}