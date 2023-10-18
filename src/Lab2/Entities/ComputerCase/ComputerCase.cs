using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public class ComputerCase : IComputerCase
{
    public ComputerCase(
        SizeType maxSizeTypeVideoCard,
        IReadOnlyCollection<MotherboardFormFactorType> motherboardFormFactorTypes,
        SizeType caseSizeType)
    {
        MaxSizeTypeVideoCard = maxSizeTypeVideoCard;
        MotherboardFormFactorSupported = motherboardFormFactorTypes;
        this.CaseSizeType = caseSizeType;
    }

    public SizeType MaxSizeTypeVideoCard { get; }
    public IReadOnlyCollection<MotherboardFormFactorType> MotherboardFormFactorSupported { get; }
    public SizeType CaseSizeType { get; }

    public bool IsComputerCaseCompatibilityWithVideoCard(IVideoCard videoCard)
    {
        return MaxSizeTypeVideoCard.Lenght >= videoCard.VideoCardSizeType.Lenght
               && MaxSizeTypeVideoCard.Width >= videoCard.VideoCardSizeType.Width;
    }

    public bool IsComputerCaseCompatibilityWithMotherboard(IMotherboard motherboard)
    {
        return MotherboardFormFactorSupported.Contains(motherboard.FormFactor);
    }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder computerCaseBuilder)
    {
        computerCaseBuilder.AddMaxSizeTypeVideoCard(MaxSizeTypeVideoCard);
        computerCaseBuilder.AddCaseSizeType(CaseSizeType);
        foreach (MotherboardFormFactorType motherboardFormFactor in MotherboardFormFactorSupported)
        {
            computerCaseBuilder.AddMotherboardFormFactorSupported(motherboardFormFactor);
        }

        return computerCaseBuilder;
    }
}