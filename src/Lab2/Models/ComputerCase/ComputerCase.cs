using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;

public class ComputerCase : IComputerCase
{
    internal ComputerCase(
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

    public IValidateResult IsComputerCaseCompatibilityWithVideoCard(IVideoCard videoCard)
    {
        if (MaxSizeTypeVideoCard.Lenght >= videoCard.VideoCardSizeType.Lenght &&
            MaxSizeTypeVideoCard.Width >= videoCard.VideoCardSizeType.Width)
            return new SuccessValidateResult.SuccessCompability();
        return new IsNotCompability<IComputerCase, IVideoCard>(this, videoCard);
    }

    public IValidateResult IsComputerCaseCompatibilityWithMotherboard(IMotherboard motherboard)
    {
        if (MotherboardFormFactorSupported.Contains(motherboard.FormFactor))
            return new SuccessValidateResult.SuccessCompability();
        return new IsNotCompability<IComputerCase, IMotherboard>(this, motherboard);
    }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder computerCaseBuilder)
    {
        computerCaseBuilder.AddMaxSizeTypeVideoCard(MaxSizeTypeVideoCard)
                           .AddCaseSizeType(CaseSizeType);
        foreach (MotherboardFormFactorType motherboardFormFactor in MotherboardFormFactorSupported)
        {
            computerCaseBuilder.AddMotherboardFormFactorSupported(motherboardFormFactor);
        }

        return computerCaseBuilder;
    }
}