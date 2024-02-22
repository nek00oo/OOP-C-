namespace Itmo.ObjectOrientedProgramming.Lab4.ExecutionContext.ValidateCommand;

public interface IValidatePath
{
    ValidatePathResult Execute(string path);
}