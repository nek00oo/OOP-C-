namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineGamma : IJumpEngine
{
    public int FuelConsumptionAe { get; } = 50;
    public int JumpRange { get; } = 200;
    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAe * distance * distance;
    }
}