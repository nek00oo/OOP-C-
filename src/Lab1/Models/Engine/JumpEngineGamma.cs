namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineGamma : JumpEngine
{
    public JumpEngineGamma()
        : base(EngineType.Gamma)
    {
    }

    public override double CalculateFuelRequired(double fuelQuantity, int distance)
    {
        return fuelQuantity - (FuelConsumptionAe * distance * distance);
    }
}