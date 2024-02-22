using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.HardDrive;

public interface IHardDriveBuilder
{
    IHardDriveBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IHardDriveBuilder AddMemoryCapacityGb(CountType memoryCapacityGb);
    IHardDriveBuilder AddSpindleSpeed(SpeedType spindleSpeed);
    IHardDrive Build();
}