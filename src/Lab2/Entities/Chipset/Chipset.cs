using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipset;

public class Chipset : IChipset
{
    public Chipset(bool xmpSupport, CountType frequency)
    {
        XmpSupport = xmpSupport;
        Frequency = frequency;
    }

    public bool XmpSupport { get; } // сделать (мб убрать свойства, сделать поля) мб функция
    public CountType Frequency { get; }
}