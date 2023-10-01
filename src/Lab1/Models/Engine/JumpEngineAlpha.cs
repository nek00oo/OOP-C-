namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineAlpha : IJumpEngine
{
    public int FuelConsumptionAe { get; } = 50;
    public int JumpRange { get; } = 50;
    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAe * distance;
    }
}