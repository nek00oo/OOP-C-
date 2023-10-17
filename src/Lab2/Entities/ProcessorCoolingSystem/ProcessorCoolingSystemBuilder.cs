using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;

public class ProcessorCoolingSystemBuilder : IProcessorCoolingSystemBuilder
{
    private readonly List<SocketType> _socketSupported;
    private CountType? _tdp;
    private SizeType? _size;

    public ProcessorCoolingSystemBuilder()
    {
        _socketSupported = new List<SocketType>();
    }

    protected CountType? PowerConsumptionV { get; private set; }

    public IProcessorCoolingSystemBuilder AddSocket(SocketType socket)
    {
        _socketSupported.Add(socket);
        return this;
    }

    public IProcessorCoolingSystemBuilder AddTdp(CountType tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorCoolingSystemBuilder AddSize(SizeType size)
    {
        _size = size;
        return this;
    }

    public IProcessorCoolingSystemBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        PowerConsumptionV = powerConsumptionV;
        return this;
    }

    public IProcessorCoolingSystem Build()
    {
        return new ProcessorCoolingSystem(
            _socketSupported ?? throw new ArgumentNullException(nameof(_socketSupported)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _size ?? throw new ArgumentNullException(nameof(_size)),
            PowerConsumptionV ?? throw new ArgumentNullException(nameof(PowerConsumptionV)));
    }
}