namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;

public interface IComputerCaseBuilderDirector
{
    IComputerCaseBuilder Direct(IComputerCaseBuilder computerCaseBuilder);
}