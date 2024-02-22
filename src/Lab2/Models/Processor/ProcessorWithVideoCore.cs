using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ProcessorWithVideoCore : IProcessorWithVideoCore
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
            return new SuccessValidateResult.SuccessCompability();
        return new IsNotCompability<IProcessorWithVideoCore, IMotherboard>(this, motherboard);
    }

    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        if (processorBuilder is IProcessorWithVideoCoreBuilder processorWithVideoCoreBuilder)
        {
            processorWithVideoCoreBuilder.AddCoreFrequency(CoreFrequency)
                .AddCountCore(CountCore)
                .AddSocket(Socket)
                .AddFrequencyMemory(FrequencyMemory)
                .AddTdp(Tdp)
                .AddPowerConsumptionV(PowerConsumptionV);
            processorWithVideoCoreBuilder.AddVideoCore(VideoCoreType);
            return processorWithVideoCoreBuilder;
        }

        processorBuilder.AddCoreFrequency(CoreFrequency)
            .AddCountCore(CountCore)
            .AddSocket(Socket)
            .AddFrequencyMemory(FrequencyMemory)
            .AddTdp(Tdp)
            .AddPowerConsumptionV(PowerConsumptionV);
        return processorBuilder;
    }
}