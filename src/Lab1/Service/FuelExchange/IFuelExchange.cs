namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public interface IFuelExchange
{
    public double ActivePlasmaPriceFuel { get; }
    public double GravitationalMatterPriceFuel { get; }
    public double FuelCost(IFuelUsage fuelType, double fuelQuantity);
}