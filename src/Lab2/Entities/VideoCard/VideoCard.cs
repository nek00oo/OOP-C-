using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class VideoCard : IVideoCard
{
    private SizeType _videoCardSizeType;
    private CountType _countVideoMemory;
    private PciEVersion _pciEVersion;
    private CountType _frequencyChip;

    public VideoCard(
        SizeType videoCardSizeType,
        CountType countVideoMemory,
        PciEVersion pciEVersion,
        CountType frequencyChip,
        CountType powerConsumptionV)
    {
        _videoCardSizeType = videoCardSizeType;
        _countVideoMemory = countVideoMemory;
        _pciEVersion = pciEVersion;
        _frequencyChip = frequencyChip;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public bool IsVideoCardCompatibility(IMotherboard motherboard)
    {
        throw new System.NotImplementedException();
    }

    public IVideoCardBuilder Direct(IVideoCardBuilder videoCardBuilder)
    {
        videoCardBuilder.AddVideoCardSize(_videoCardSizeType);
        videoCardBuilder.AddCountVideoMemory(_countVideoMemory);
        videoCardBuilder.AddPciEVersion(_pciEVersion);
        videoCardBuilder.AddFrequencyChip(_frequencyChip);
        videoCardBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return videoCardBuilder;
    }
}