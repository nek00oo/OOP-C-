using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public class FlagsArgument
{
    public FlagsArgument(int? depth = null, IOutputMode? mode = null, FileSystemMode? fileSystemMode = null)
    {
        Depth = depth;
        OutputMode = mode;
        FileSystemMode = fileSystemMode;
    }

    public int? Depth { get; }
    public IOutputMode? OutputMode { get; }
    public FileSystemMode? FileSystemMode { get; }

    public FlagsArgument WithDepth(int depth) => new FlagsArgument(depth, OutputMode, FileSystemMode);
    public FlagsArgument WithOutputMode(IOutputMode mode) => new FlagsArgument(Depth, mode, FileSystemMode);

    public FlagsArgument WithFileSystemMode(FileSystemMode fileSystemMode) =>
        new FlagsArgument(Depth, OutputMode, fileSystemMode);
}