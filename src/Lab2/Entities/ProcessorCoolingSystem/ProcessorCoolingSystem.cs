using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

public class ProcessorCoolingSystem : IProcessorCoolingSystem
{
    private IReadOnlyCollection<SocketType> _socketSupported;
    private CountType _tdp;
    private SizeType _size;

    public ProcessorCoolingSystem(
        IReadOnlyCollection<SocketType> socket,
        CountType tdp,
        SizeType size,
        CountType powerConsumptionV)
    {
        _socketSupported = socket;
        _tdp = tdp;
        _size = size;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public IProcessorCoolingSystemBuilder Direct(IProcessorCoolingSystemBuilder processorCoolingSystemBuilder)
    {
        foreach (SocketType socketType in _socketSupported)
        {
            processorCoolingSystemBuilder.AddSocket(socketType);
        }

        processorCoolingSystemBuilder.AddTdp(_tdp);
        processorCoolingSystemBuilder.AddSize(_size);
        processorCoolingSystemBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return processorCoolingSystemBuilder;
    }
}