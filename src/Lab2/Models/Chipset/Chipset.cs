using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Chipset;

public class Chipset : IChipset
{
    public Chipset(bool xmpSupport, CountType frequency)
    {
        XmpSupport = xmpSupport;
        Frequency = frequency;
    }

    public bool XmpSupport { get; }
    public CountType Frequency { get; }
}