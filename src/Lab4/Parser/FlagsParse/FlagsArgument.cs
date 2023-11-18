using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class FlagsArgument
{
    public FlagsArgument(int? depth = null, IOutputMode? mode = null)
    {
        Depth = depth;
        OutputMode = mode;
    }

    public int? Depth { get; }
    public IOutputMode? OutputMode { get; }

    public FlagsArgument WithDepth(int depth) => new FlagsArgument(depth, OutputMode);
    public FlagsArgument WithMode(IOutputMode mode) => new FlagsArgument(Depth, mode);
}