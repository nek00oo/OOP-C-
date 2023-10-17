using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorWithVideoCore : IProcessor, IProcessorWithVideoCore
{
    private VideoCoreType _videoCoreType;
    private CountType _coreFrequency;
    private CountType _countCore;
    private SocketType _socket;
    private CountType _frequencyMemory;
    private CountType _tdp;

    public ProcessorWithVideoCore(
        CountType coreFrequency,
        CountType countCore,
        SocketType socket,
        CountType frequencyMemory,
        CountType tdp,
        CountType powerConsumptionV,
        VideoCoreType videoCoreType)
    {
        _coreFrequency = coreFrequency;
        _countCore = countCore;
        _socket = socket;
        _frequencyMemory = frequencyMemory;
        _tdp = tdp;
        PowerConsumptionV = powerConsumptionV;
        _videoCoreType = videoCoreType;
    }

    public CountType PowerConsumptionV { get; }

    public bool IsCoolingSystemCompatibility(IProcessorCoolingSystem coolingSystem)
    {
        throw new System.NotImplementedException();
    }

    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        if (processorBuilder is IProcessorWithVideoCoreBuilder processorWithVideoCoreBuilder)
        {
            processorWithVideoCoreBuilder.AddCoreFrequency(_coreFrequency);
            processorWithVideoCoreBuilder.AddCountCore(_countCore);
            processorWithVideoCoreBuilder.AddSocket(_socket);
            processorWithVideoCoreBuilder.AddFrequencyMemory(_frequencyMemory);
            processorWithVideoCoreBuilder.AddTdp(_tdp);
            processorWithVideoCoreBuilder.AddPowerConsumptionV(PowerConsumptionV);
            processorWithVideoCoreBuilder.AddVideoCore(_videoCoreType);
            return processorWithVideoCoreBuilder;
        }

        processorBuilder.AddCoreFrequency(_coreFrequency);
        processorBuilder.AddCountCore(_countCore);
        processorBuilder.AddSocket(_socket);
        processorBuilder.AddFrequencyMemory(_frequencyMemory);
        processorBuilder.AddTdp(_tdp);
        processorBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return processorBuilder;
    }
}