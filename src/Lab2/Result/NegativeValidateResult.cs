namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public abstract record NegativeValidateResult : INegativeValidateResult
{
    private NegativeValidateResult() { }

    public sealed record InsufficientPowerThePowerUnit() : NegativeValidateResult;

    public sealed record VideoCardIsRequired() : NegativeValidateResult;
}