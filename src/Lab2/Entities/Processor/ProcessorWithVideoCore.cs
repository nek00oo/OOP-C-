using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorWithVideoCore : IProcessor, IProcessorWithVideoCore
{
    public ProcessorWithVideoCore(
        CountType coreFrequency,
        CountType countCore,
        SocketType socket,
        CountType frequencyMemory,
        CountType tdp,
        CountType powerConsumptionV,
        VideoCoreType videoCoreType)
    {
        CoreFrequency = coreFrequency;
        CountCore = countCore;
        Socket = socket;
        FrequencyMemory = frequencyMemory;
        Tdp = tdp;
        PowerConsumptionV = powerConsumptionV;
        VideoCoreType = videoCoreType;
    }

    public VideoCoreType VideoCoreType { get; }
    public CountType CoreFrequency { get; }
    public CountType CountCore { get; }
    public SocketType Socket { get; }
    public CountType FrequencyMemory { get; }
    public CountType Tdp { get; }

    public CountType PowerConsumptionV { get; }

    public IValidateResult IsProcessorCompatibility(IMotherboard motherboard)
    {
        if (Socket == motherboard.Socket && motherboard.Bios.IsProcessorCompatibleWithMotherboard(this))
            return new SuccessValidateResult.MotherboardAndProcessorCompability();
        return new NegativeValidateResult.MotherboardAndProcessorIsNotCompability();
    }

    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        if (processorBuilder is IProcessorWithVideoCoreBuilder processorWithVideoCoreBuilder)
        {
            processorWithVideoCoreBuilder.AddCoreFrequency(CoreFrequency);
            processorWithVideoCoreBuilder.AddCountCore(CountCore);
            processorWithVideoCoreBuilder.AddSocket(Socket);
            processorWithVideoCoreBuilder.AddFrequencyMemory(FrequencyMemory);
            processorWithVideoCoreBuilder.AddTdp(Tdp);
            processorWithVideoCoreBuilder.AddPowerConsumptionV(PowerConsumptionV);
            processorWithVideoCoreBuilder.AddVideoCore(VideoCoreType);
            return processorWithVideoCoreBuilder;
        }

        processorBuilder.AddCoreFrequency(CoreFrequency);
        processorBuilder.AddCountCore(CountCore);
        processorBuilder.AddSocket(Socket);
        processorBuilder.AddFrequencyMemory(FrequencyMemory);
        processorBuilder.AddTdp(Tdp);
        processorBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return processorBuilder;
    }
}