using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.IconVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;
using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext;

public interface IExecuteContext
{
    IValidatePath FileExistValidate { get; }
    IValidatePath DirectoryExistValidate { get; }
    IValidatePath PathExistValidate { get; }
    IValidatePath RootPathValidate { get; }
    OperationResult Disconnect();
    OperationResult TreeGoTo(string path);
    OperationResult TreeList(IOutputMode outputMode, IIconsVisitor? iconsVisitor, int depth = 1);
    OperationResult ShowFile(IOutputMode outputMode, string filename);
    OperationResult MoveFile(string sourcePath, string destinationPath);
    OperationResult CopyFile(string sourcePath, string destinationPath);
    OperationResult FileDelete(string fileName);
    OperationResult RenameFile(string filePath, string newFileName);
    string GetFullPath(string path);
}