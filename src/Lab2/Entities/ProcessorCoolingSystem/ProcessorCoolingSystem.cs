using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

public class ProcessorCoolingSystem : IProcessorCoolingSystem
{
    public ProcessorCoolingSystem(
        IReadOnlyCollection<SocketType> socket,
        CountType tdp,
        SizeType size,
        CountType powerConsumptionV)
    {
        SocketSupported = socket;
        Tdp = tdp;
        this.Size = size;
        PowerConsumptionV = powerConsumptionV;
    }

    public IReadOnlyCollection<SocketType> SocketSupported { get; }
    public CountType Tdp { get; }
    public SizeType Size { get; }
    public CountType PowerConsumptionV { get; }
    public bool IsCoolingSystemCompatibility(IProcessor processor)
    {
        return SocketSupported.Contains(processor.Socket);
    }

    public IProcessorCoolingSystemBuilder Direct(IProcessorCoolingSystemBuilder processorCoolingSystemBuilder)
    {
        foreach (SocketType socketType in SocketSupported)
        {
            processorCoolingSystemBuilder.AddSocket(socketType);
        }

        processorCoolingSystemBuilder.AddTdp(Tdp);
        processorCoolingSystemBuilder.AddSize(Size);
        processorCoolingSystemBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return processorCoolingSystemBuilder;
    }
}