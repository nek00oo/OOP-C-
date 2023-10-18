using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;

public interface IXmp
{
    // XMP - профиль, по которому плата смотрит, как взаимодейстовать с RAM (частоты, вольтаж)
    public CountType FrequencyChip { get; } // вроде это частота оперативки
    public CountType PowerConsumptionV { get; }

    // тайминги
}