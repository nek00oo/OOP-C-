using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ProcessorCoolingSystem;

public interface IProcessorCoolingSystem : IProcessorCoolingSystemBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public IValidateResult IsCoolingSystemCompatibility(IProcessor processor);
}