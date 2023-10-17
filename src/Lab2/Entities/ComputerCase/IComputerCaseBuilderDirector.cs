namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCaseBuilderDirector
{
    IComputerCaseBuilder Direct(IComputerCaseBuilder computerCaseBuilder);
}