using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public class FileIsExistPath : IValidatePath
{
    public ValidatePathResult Execute(string path)
    {
        if (File.Exists(path) is false)
            return new ValidatePathResult.NotExist("the specified file does not exist");
        return new ValidatePathResult.Success();
    }
}