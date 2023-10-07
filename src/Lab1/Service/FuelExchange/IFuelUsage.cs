namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public interface IFuelUsage
{
    public double FuelQuantity { get; }
    public void CalculateFuelRequired(int distance);
}