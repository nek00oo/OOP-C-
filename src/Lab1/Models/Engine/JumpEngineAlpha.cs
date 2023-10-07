using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineAlpha : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeAlphaEngine = 50;
    private const double JumpTimeAlphaEngine = 3;

    public double FuelQuantity { get; private set; }

    public FlyResult FlyingSpaceСanal(int distance)
    {
        if (distance < JumpRangeAlphaEngine)
            return new FlyResult.SuccessFlight(JumpTimeAlphaEngine);
        return new FlyResult.ImpossibleFlight();
    }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAeJumpEngine * distance;
    }
}