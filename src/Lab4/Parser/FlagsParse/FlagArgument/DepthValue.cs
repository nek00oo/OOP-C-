namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

public class DepthValue : IFlagArgument
{
    public DepthValue(int? depth)
    {
        Depth = depth;
    }

    public int? Depth { get; }
}