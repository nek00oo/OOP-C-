using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;

public interface IVideoCard : IVideoCardBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public SizeType VideoCardSizeType { get; }
    public CountType CountVideoMemory { get; }
    public PciEVersion PciEVersion { get; }
    public CountType FrequencyChip { get; }
}