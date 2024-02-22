using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HardDrive;

public class HardDrive : IHardDrive
{
    internal HardDrive(CountType powerConsumptionV, CountType memoryCapacityGb, SpeedType spindleSpeed)
    {
        PowerConsumptionV = powerConsumptionV;
        MemoryCapacityGb = memoryCapacityGb;
        SpindleSpeed = spindleSpeed;
    }

    public CountType PowerConsumptionV { get; }
    public CountType MemoryCapacityGb { get; }
    public SpeedType SpindleSpeed { get; }

    public IHardDriveBuilder Direct(IHardDriveBuilder hardDriveBuilder)
    {
        hardDriveBuilder.AddPowerConsumptionV(PowerConsumptionV)
            .AddMemoryCapacityGb(MemoryCapacityGb)
            .AddSpindleSpeed(SpindleSpeed);
        return hardDriveBuilder;
    }
}