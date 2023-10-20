namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public class UsageFuelActivePlasma : IUsageFuelActivePlasma
{
    public UsageFuelActivePlasma(double fuelQuantity)
    {
        FuelQuantity = fuelQuantity;
    }

    public double FuelQuantity { get; }
}