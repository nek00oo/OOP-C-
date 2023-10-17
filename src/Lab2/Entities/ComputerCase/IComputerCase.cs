using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCase : IComputerCaseBuilderDirector, IComputerComponent
{
    public bool IsComputerCaseCompatibility(IVideoCard videoCard);
    public bool IsComputerCaseCompatibility(IMotherboard motherboard);
}