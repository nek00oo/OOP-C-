namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.FlagsParse.FlagArgument;

public class FileSystemModeValue : IFlagArgument
{
    public FileSystemModeValue(FileSystemMode? fileSystemMode)
    {
        SystemMode = fileSystemMode;
    }

    public FileSystemMode? SystemMode { get; }
}