using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;

public interface IJedec
{
    // JEDEC - профиль, по которому плата смотрит, как взаимодейстовать с RAM (частоты, вольтаж)
    // общие рекомендации (в отличии от XMP)
    public CountType FrequencyChip { get; } // вроде это частота оперативки
    public CountType PowerConsumptionV { get; }
}