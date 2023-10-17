using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IProcessorBuilderComputer
{
    IProcessorCoolingSystemBuilderComputer AddProcessor(IProcessor processor);
}