using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.XMP;

public class Xmp : IXmp
{
    public Xmp(CountType frequencyChip, CountType powerConsumptionV)
    {
        FrequencyChip = frequencyChip;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType FrequencyChip { get; }
    public CountType PowerConsumptionV { get; }
}