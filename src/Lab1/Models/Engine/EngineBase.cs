namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public abstract class EngineBase
{
    protected const int FuelConsumptionAe = 50;

    protected EngineBase(EngineType engineType)
    {
        EngineType = engineType;
    }

    public EngineType EngineType { get; private set; }
    public abstract double CalculateFuelRequired(double fuelQuantity, int distance);
}