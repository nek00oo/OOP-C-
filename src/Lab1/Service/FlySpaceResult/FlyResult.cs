namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

public abstract record FlyResult
{
    private FlyResult() { }

    public sealed record SuccessFlight(double TimeRoute) : FlyResult;

    public sealed record ImpossibleFlight() : FlyResult;
}