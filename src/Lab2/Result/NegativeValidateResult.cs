namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public abstract record NegativeValidateResult : IValidateResult
{
    private NegativeValidateResult() { }

    public sealed record MotherboardAndProcessorIsNotCompability() : NegativeValidateResult;

    public sealed record ProcessorAndProcessorCoolingSystemIsNotCompability() : NegativeValidateResult;

    public sealed record RamMemoryAndMotherboardIsNotCompability() : NegativeValidateResult;

    public sealed record ComputerCaseAndMotherboardIsNotCompability() : NegativeValidateResult;

    public sealed record ComputerCaseAndVideoCardIsNotCompability() : NegativeValidateResult;

    public sealed record WiFiAdapterAndMotherboardIsNotCompability() : NegativeValidateResult;

    public sealed record VideoCardIsRequired() : NegativeValidateResult;

    public sealed record DisclaimerWarrantyObligations() : NegativeValidateResult;
}