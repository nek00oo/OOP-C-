using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public class Directory : IDirectory
{
    public IExecuteContext Connect(string path, FileSystemMode fileSystemMode)
    {
        return fileSystemMode switch
        {
            FileSystemMode.Local => new LocalExecuteContext(path),
            _ => throw new InvalidOperationException("execution context not implemented"),
        };
    }

    public void Disconnect()
    {
        throw new System.NotImplementedException();
    }
}