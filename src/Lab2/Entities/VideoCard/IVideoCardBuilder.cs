using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IVideoCardBuilder
{
    IVideoCardBuilder AddVideoCardSize(SizeType videoCardSizeType);
    IVideoCardBuilder AddCountVideoMemory(CountType countVideoMemory);
    IVideoCardBuilder AddPciEVersion(PciEVersion pciEVersion);
    IVideoCardBuilder AddFrequencyChip(CountType frequencyChip);
    IVideoCardBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IVideoCard Build();
}