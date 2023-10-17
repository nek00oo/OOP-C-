using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public class Xmp : IXMP
{
    public Xmp(CountType frequencyChip, CountType powerConsumptionV)
    {
        FrequencyChip = frequencyChip;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType FrequencyChip { get; }
    public CountType PowerConsumptionV { get; }
}