using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;

public class Ssd : ISsd
{
    public Ssd(CountType powerConsumptionV, CountType memoryCapacityGb, SpeedType maxBandWidth)
    {
        PowerConsumptionV = powerConsumptionV;
        MemoryCapacityGb = memoryCapacityGb;
        MaxBandWidth = maxBandWidth;
    }

    public CountType PowerConsumptionV { get; }
    public CountType MemoryCapacityGb { get; }
    public SpeedType MaxBandWidth { get; }
    public bool IsConnectMotherBoard(IMotherboard motherboard)
    {
        throw new System.NotImplementedException();
    }

    public ISsdBuilder Direct(ISsdBuilder ssdBuilder)
    {
        ssdBuilder.AddPowerConsumptionV(PowerConsumptionV);
        ssdBuilder.AddMemoryCapacityGb(MemoryCapacityGb);
        ssdBuilder.AddMaxBandWidth(MaxBandWidth);
        return ssdBuilder;
    }
}