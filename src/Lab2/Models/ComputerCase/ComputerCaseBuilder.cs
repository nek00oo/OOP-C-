using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private readonly List<MotherboardFormFactorType> _motherboardFormFactorSupported;
    private SizeType? _maxSizeTypeVideoCard;
    private SizeType? _caseSizeType;

    public ComputerCaseBuilder()
    {
        _motherboardFormFactorSupported = new List<MotherboardFormFactorType>();
    }

    public IComputerCaseBuilder AddMaxSizeTypeVideoCard(SizeType maxSizeTypeVideoCard)
    {
        _maxSizeTypeVideoCard = maxSizeTypeVideoCard;
        return this;
    }

    public IComputerCaseBuilder AddMotherboardFormFactorSupported(MotherboardFormFactorType motherboardFormFactorSupported)
    {
        _motherboardFormFactorSupported.Add(motherboardFormFactorSupported);
        return this;
    }

    public IComputerCaseBuilder AddCaseSizeType(SizeType caseSizeType)
    {
        _caseSizeType = caseSizeType;
        return this;
    }

    public IComputerCase Build()
    {
        return new Models.ComputerCase.ComputerCase(
            _maxSizeTypeVideoCard ?? throw new ArgumentNullException(nameof(_maxSizeTypeVideoCard)),
            _motherboardFormFactorSupported ?? throw new ArgumentNullException(nameof(_motherboardFormFactorSupported)),
            _caseSizeType ?? throw new ArgumentNullException(nameof(_caseSizeType)));
    }
}