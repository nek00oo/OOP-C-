using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public class VideoCardBuilder : IVideoCardBuilder
{
    private SizeType? _videoCardSizeType;
    private CountType? _countVideoMemory;
    private PciEVersion? _pciEVersion;
    private CountType? _frequencyChip;

    public CountType? PowerConsumptionV { get; private set; }

    public IVideoCardBuilder AddVideoCardSize(SizeType videoCardSizeType)
    {
        _videoCardSizeType = videoCardSizeType;
        return this;
    }

    public IVideoCardBuilder AddCountVideoMemory(CountType countVideoMemory)
    {
        _countVideoMemory = countVideoMemory;
        return this;
    }

    public IVideoCardBuilder AddPciEVersion(PciEVersion pciEVersion)
    {
        _pciEVersion = pciEVersion;
        return this;
    }

    public IVideoCardBuilder AddFrequencyChip(CountType frequencyChip)
    {
        _frequencyChip = frequencyChip;
        return this;
    }

    public IVideoCardBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        PowerConsumptionV = powerConsumptionV;
        return this;
    }

    public IVideoCard Build()
    {
        return new VideoCard(
            _videoCardSizeType ?? throw new ArgumentNullException(nameof(_videoCardSizeType)),
            _countVideoMemory ?? throw new ArgumentNullException(nameof(_countVideoMemory)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _frequencyChip ?? throw new ArgumentNullException(nameof(_frequencyChip)),
            PowerConsumptionV ?? throw new ArgumentNullException(nameof(PowerConsumptionV)));
    }
}