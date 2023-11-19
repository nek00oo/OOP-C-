using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse;

public record FlagArguments(int? Depth = null, IOutputMode? OutputMode = null, FileSystemMode? FileSystemMode = null);