using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IProcessor : IProcessorBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public bool IsCoolingSystemCompatibility(IProcessorCoolingSystem coolingSystem); // по сокету + комментарий о гарантии
}