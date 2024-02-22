using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Jedec;

public class Jedec : IJedec
{
    public Jedec(CountType frequencyChip, CountType powerConsumptionV)
    {
        FrequencyChip = frequencyChip;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType FrequencyChip { get; }
    public CountType PowerConsumptionV { get; }
}