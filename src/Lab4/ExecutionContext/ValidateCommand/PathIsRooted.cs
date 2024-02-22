using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public class PathIsRooted : IValidatePath
{
    public ValidatePathResult Execute(string path)
    {
        if (Path.IsPathRooted(path) is false)
            return new ValidatePathResult.NotExist("a non-absolute path in the attached file system was passed");
        return new ValidatePathResult.Success();
    }
}