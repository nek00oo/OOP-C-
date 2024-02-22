using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Chipset;

public interface IChipset
{
    public bool XmpSupport { get; }
    public CountType Frequency { get; }
}