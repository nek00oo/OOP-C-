namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public abstract record SuccessValidateResult : ISuccessValidateResult
{
    private SuccessValidateResult() { }

    public sealed record SuccessCompability() : SuccessValidateResult;

    public sealed record DisclaimerWarrantyObligations() : SuccessValidateResult;

    public sealed record FailureComplyWithRecommendedPowerPowerUnit() : SuccessValidateResult;
}