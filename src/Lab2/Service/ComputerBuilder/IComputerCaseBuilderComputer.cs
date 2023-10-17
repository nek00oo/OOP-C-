using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IComputerCaseBuilderComputer
{
    IConfigurator AddComputerCase(IComputerCase computerCase);
}