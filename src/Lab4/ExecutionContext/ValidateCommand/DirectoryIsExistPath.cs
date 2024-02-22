using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public class DirectoryIsExistPath : IValidatePath
{
    public ValidatePathResult Execute(string path)
    {
        if (Directory.Exists(path) is false)
            return new ValidatePathResult.NotExist("the specified directory does not exist");
        return new ValidatePathResult.Success();
    }
}