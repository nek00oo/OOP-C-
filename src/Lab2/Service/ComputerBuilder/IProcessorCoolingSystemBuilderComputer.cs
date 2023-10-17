using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IProcessorCoolingSystemBuilderComputer
{
    IRamMemoryBuilderComputer AddProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem);
}