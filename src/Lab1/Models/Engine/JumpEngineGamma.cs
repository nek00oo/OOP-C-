using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineGamma : IJumpEngine
{
    private const int FuelConsumptionAeJumpEngine = 50;
    private const int JumpRangeGammaEngine = 200;
    private const double JumpTimeGammaEngine = 1;

    public double FuelQuantity { get; private set; }

    public FlyResult FlyingSpaceСanal(int distance)
    {
        if (distance < JumpRangeGammaEngine)
            return new FlyResult.SuccessFlight(JumpTimeGammaEngine);
        return new FlyResult.ImpossibleFlight();
    }

    public void CalculateFuelRequired(int distance)
    {
        FuelQuantity += FuelConsumptionAeJumpEngine * distance * distance;
    }
}