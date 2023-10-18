namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

public interface IProcessorCoolingSystem : IProcessorCoolingSystemBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public bool IsCoolingSystemCompatibility(IProcessor processor); // по сокету + комментарий о гарантии
}