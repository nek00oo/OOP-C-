namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineAlpha : JumpEngine
{
    public JumpEngineAlpha()
        : base(EngineType.Alpha)
    {
    }

    public override double CalculateFuelRequired(double fuelQuantity, int distance)
    {
        return fuelQuantity - (FuelConsumptionAe * distance);
    }
}