using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public interface ISsdBuilder
{
    ISsdBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    ISsdBuilder AddMemoryCapacityGb(CountType memoryCapacityGb);
    ISsdBuilder AddMaxBandWidth(SpeedType maxBandWidth);
    ISsdBuilder AddPortType(PortType portType);
    ISsd Build();
}