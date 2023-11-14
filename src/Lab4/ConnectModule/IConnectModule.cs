using Itmo.ObjectOrientedProgramming.Lab4.OutputMode;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConnectModule;

public interface IConnectModule
{
    ConnectResult Connect(string path);
    void Disconnect();
    ConnectResult TreeGoTo(string path);
    ConnectResult TreeList(IOutputMode outputMode, int depth = 1);
    ConnectResult ShowFile(IOutputMode outputMode, string filename);
    ConnectResult MoveFile(string sourcePath, string destinationPath);
    ConnectResult CopyFile(string sourcePath, string destinationPath);
    ConnectResult FileDelete(string fileName);
    ConnectResult RenameFile(string filePath, string newFileName);
}