using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;

public interface IComputerCase : IComputerCaseBuilderDirector, IComputerComponent
{
    public SizeType MaxSizeTypeVideoCard { get; }
    public IReadOnlyCollection<MotherboardFormFactorType> MotherboardFormFactorSupported { get; }
    public SizeType CaseSizeType { get; }
    public IValidateResult IsComputerCaseCompatibilityWithVideoCard(IVideoCard videoCard);
    public IValidateResult IsComputerCaseCompatibilityWithMotherboard(IMotherboard motherboard);
}