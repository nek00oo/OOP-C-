using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public class PathIsExistPath : IValidatePath
{
    public ValidatePathResult Execute(string path)
    {
        if (Path.Exists(path) is false)
            return new ValidatePathResult.NotExist("the specified path does not exist");
        return new ValidatePathResult.Success();
    }
}