using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HardDrive;

public class HardDriveBuilder : IHardDriveBuilder
{
    private CountType? _powerConsumptionV;
    private CountType? _memoryCapacityGb;
    private SpeedType? _spindleSpeed;

    public IHardDriveBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        _powerConsumptionV = powerConsumptionV;
        return this;
    }

    public IHardDriveBuilder AddMemoryCapacityGb(CountType memoryCapacityGb)
    {
        _memoryCapacityGb = memoryCapacityGb;
        return this;
    }

    public IHardDriveBuilder AddSpindleSpeed(SpeedType spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public IHardDrive Build()
    {
        return new HardDrive(
            _powerConsumptionV ?? throw new ArgumentNullException(nameof(_powerConsumptionV)),
            _memoryCapacityGb ?? throw new ArgumentNullException(nameof(_memoryCapacityGb)),
            _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)));
    }
}