using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

public interface IVideoCard : IVideoCardBuilderDirect, IConsumeEnergy, IComputerComponent
{
    public bool IsVideoCardCompatibility(IMotherboard motherboard);
}