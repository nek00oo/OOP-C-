using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public interface IExecuteContext
{
    OperationResult Connect(string path, FileSystemMode fileSystemMode);
    OperationResult Disconnect();
    OperationResult TreeGoTo(string path);
    OperationResult TreeList(IOutputMode outputMode, int depth = 1);
    OperationResult ShowFile(IOutputMode outputMode, string filename);
    OperationResult MoveFile(string sourcePath, string destinationPath);
    OperationResult CopyFile(string sourcePath, string destinationPath);
    OperationResult FileDelete(string fileName);
    OperationResult RenameFile(string filePath, string newFileName);
}