using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.SSD;

public class SsdBuilder : ISsdBuilder
{
    private CountType? _powerConsumptionV;
    private CountType? _memoryCapacityGb;
    private SpeedType? _maxBandWidth;
    private PortType? _portType;

    public ISsdBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        _powerConsumptionV = powerConsumptionV;
        return this;
    }

    public ISsdBuilder AddMemoryCapacityGb(CountType memoryCapacityGb)
    {
        _memoryCapacityGb = memoryCapacityGb;
        return this;
    }

    public ISsdBuilder AddMaxBandWidth(SpeedType maxBandWidth)
    {
        _maxBandWidth = maxBandWidth;
        return this;
    }

    public ISsdBuilder AddPortType(PortType portType)
    {
        _portType = portType;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(
            _powerConsumptionV ?? throw new ArgumentNullException(nameof(_powerConsumptionV)),
            _memoryCapacityGb ?? throw new ArgumentNullException(nameof(_memoryCapacityGb)),
            _maxBandWidth ?? throw new ArgumentNullException(nameof(_maxBandWidth)),
            _portType ?? throw new ArgumentNullException(nameof(_portType)));
    }
}