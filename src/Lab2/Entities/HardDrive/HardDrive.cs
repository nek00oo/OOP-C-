using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.HardDrive;

public class HardDrive : IHardDrive
{
    public HardDrive(CountType powerConsumptionV, CountType memoryCapacityGb, SpeedType spindleSpeed)
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
        hardDriveBuilder.AddPowerConsumptionV(PowerConsumptionV);
        hardDriveBuilder.AddMemoryCapacityGb(MemoryCapacityGb);
        hardDriveBuilder.AddSpindleSpeed(SpindleSpeed);
        return hardDriveBuilder;
    }
}