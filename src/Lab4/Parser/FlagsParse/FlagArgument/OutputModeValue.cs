using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

public class OutputModeValue : IFlagArgument
{
    public OutputModeValue(IOutputMode? outputMode)
    {
        Mode = outputMode;
    }

    public IOutputMode? Mode { get; }
}