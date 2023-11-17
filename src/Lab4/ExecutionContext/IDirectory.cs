namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public interface IDirectory
{
    public IExecuteContext Connect(string path, FileSystemMode fileSystemMode);
    public void Disconnect();
}