namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public abstract record SuccessValidateResult : ISuccessValidateResult
{
    private SuccessValidateResult() { }

    public sealed record MotherboardAndProcessorCompability() : SuccessValidateResult;

    public sealed record ProcessorAndProcessorCoolingSystemCompability() : SuccessValidateResult;

    public sealed record RamMemoryAndMotherboardCompability() : SuccessValidateResult;

    public sealed record ComputerCaseAndMotherboardCompability() : SuccessValidateResult;

    public sealed record ComputerCaseAndVideoCardCompability() : SuccessValidateResult;

    public sealed record WiFiAdapterAndMotherboardCompability() : SuccessValidateResult;

    public sealed record DisclaimerWarrantyObligations() : SuccessValidateResult;
}