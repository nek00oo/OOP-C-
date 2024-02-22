namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;

public class UsageFuelGravitonMatter : IUsageFuelGravitonMatter
{
    public UsageFuelGravitonMatter(double fuelQuantity)
    {
        FuelQuantity = fuelQuantity;
    }

    public double FuelQuantity { get; }
}