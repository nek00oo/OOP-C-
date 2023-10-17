using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public class ComputerCase : IComputerCase
{
    private SizeType _maxSizeTypeVideoCard;
    private IReadOnlyCollection<MotherboardFormFactorType> _motherboardFormFactorSupported;
    private SizeType _caseSizeType;

    public ComputerCase(
        SizeType maxSizeTypeVideoCard,
        IReadOnlyCollection<MotherboardFormFactorType> motherboardFormFactorTypes,
        SizeType caseSizeType)
    {
        _maxSizeTypeVideoCard = maxSizeTypeVideoCard;
        _motherboardFormFactorSupported = motherboardFormFactorTypes;
        _caseSizeType = caseSizeType;
    }

    public bool IsComputerCaseCompatibility(IVideoCard videoCard)
    {
        throw new System.NotImplementedException();
    }

    public bool IsComputerCaseCompatibility(IMotherboard motherboard)
    {
        throw new System.NotImplementedException();
    }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder computerCaseBuilder)
    {
        computerCaseBuilder.AddMaxSizeTypeVideoCard(_maxSizeTypeVideoCard);
        computerCaseBuilder.AddCaseSizeType(_caseSizeType);
        foreach (MotherboardFormFactorType motherboardFormFactor in _motherboardFormFactorSupported)
        {
            computerCaseBuilder.AddMotherboardFormFactorSupported(motherboardFormFactor);
        }

        return computerCaseBuilder;
    }
}