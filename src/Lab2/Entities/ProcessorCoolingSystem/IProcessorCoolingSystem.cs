using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

public interface IProcessorCoolingSystem : IProcessorCoolingSystemBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsCoolingSystemCompatibility(IProcessor processor);
}