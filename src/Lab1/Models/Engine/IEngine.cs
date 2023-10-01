namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IEngine
{
    public int FuelConsumptionAe { get; }
    public void CalculateFuelRequired(int distance);
}