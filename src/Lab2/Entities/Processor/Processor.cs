using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Processor : IProcessor
{
    private CountType _coreFrequency;
    private CountType _countCore;
    private SocketType _socket;
    private CountType _frequencyMemory;
    private CountType _tdp;

    public Processor(
        CountType coreFrequency,
        CountType countCore,
        SocketType socket,
        CountType frequencyMemory,
        CountType tdp,
        CountType powerConsumptionV)
    {
        _coreFrequency = coreFrequency;
        _countCore = countCore;
        _socket = socket;
        _frequencyMemory = frequencyMemory;
        _tdp = tdp;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public bool IsCoolingSystemCompatibility(IProcessorCoolingSystem coolingSystem)
    {
        throw new System.NotImplementedException();
    }

    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        processorBuilder.AddCoreFrequency(_coreFrequency);
        processorBuilder.AddCountCore(_countCore);
        processorBuilder.AddSocket(_socket);
        processorBuilder.AddFrequencyMemory(_frequencyMemory);
        processorBuilder.AddTdp(_tdp);
        processorBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return processorBuilder;
    }
}