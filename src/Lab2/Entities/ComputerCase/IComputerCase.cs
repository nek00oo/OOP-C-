using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCase : IComputerCaseBuilderDirector, IComputerComponent
{
    public IValidateResult IsComputerCaseCompatibilityWithVideoCard(IVideoCard videoCard);
    public IValidateResult IsComputerCaseCompatibilityWithMotherboard(IMotherboard motherboard);
}