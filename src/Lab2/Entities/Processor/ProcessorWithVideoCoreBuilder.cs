using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProcessorWithVideoCoreBuilder : IProcessorBuilder, IProcessorWithVideoCoreBuilder
{
    private VideoCoreType? _videoCore;
    private CountType? _coreFrequency;
    private CountType? _countCore;
    private SocketType? _socket;
    private CountType? _frequencyMemory;
    private CountType? _tdp;
    public CountType? PowerConsumptionV { get; private set; }

    public IProcessorBuilder AddCoreFrequency(CountType coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessorBuilder AddCountCore(CountType countCore)
    {
        _countCore = countCore;
        return this;
    }

    public IProcessorBuilder AddSocket(SocketType socket)
    {
        _socket = socket;
        return this;
    }

    public IProcessorBuilder AddFrequencyMemory(CountType frequencyMemory)
    {
        _frequencyMemory = frequencyMemory;
        return this;
    }

    public IProcessorBuilder AddTdp(CountType tdp)
    {
        _tdp = tdp;
        return this;
    }

    public IProcessorBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        PowerConsumptionV = powerConsumptionV;
        return this;
    }

    public IProcessorWithVideoCoreBuilder AddVideoCore(VideoCoreType videoCore)
    {
        _videoCore = videoCore;
        return this;
    }

    public IProcessor Build()
    {
        return new ProcessorWithVideoCore(
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _countCore ?? throw new ArgumentNullException(nameof(_countCore)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _frequencyMemory ?? throw new ArgumentNullException(nameof(_frequencyMemory)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            PowerConsumptionV ?? throw new ArgumentNullException(nameof(PowerConsumptionV)),
            _videoCore ?? throw new ArgumentNullException(nameof(_videoCore)));
    }
}