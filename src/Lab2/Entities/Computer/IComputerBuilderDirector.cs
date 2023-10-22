using Itmo.ObjectOrientedProgramming.Lab2.Service;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

public interface IComputerBuilderDirector
{
    IConfigurator Direct(IConfigurator configurator);
}