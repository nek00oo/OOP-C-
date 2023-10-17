namespace Itmo.ObjectOrientedProgramming.Lab2.Type;

public abstract record ConfiguratorNegativeResult
{
    private ConfiguratorNegativeResult() { }

    public sealed record ProcessorIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record CoolingSystemIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record RamIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record SsdIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record VideoCardIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record WiFiAdapterIsNotCompatible() : ConfiguratorNegativeResult;

    public sealed record ComputerCaseIsNotCompatible() : ConfiguratorNegativeResult;
}