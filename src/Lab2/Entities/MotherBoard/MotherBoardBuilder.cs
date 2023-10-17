using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoardBuilder : IMotherBoardBuilder
{
    private CountType? _countSataPorts;
    private CountType? _countPciELines;
    private CountType? _countRamSlots;
    private MotherboardFormFactorType? _formFactor;
    private IBios? _bios;
    private DdrType? _ddrType;
    private IChipset? _chipset;
    private SocketType? _socket;

    public IMotherBoardBuilder AddCountSataPorts(CountType countSataPorts)
    {
        _countSataPorts = countSataPorts;
        return this;
    }

    public IMotherBoardBuilder AddCountPciELines(CountType countPciELines)
    {
        _countPciELines = countPciELines;
        return this;
    }

    public IMotherBoardBuilder AddCountRamSlots(CountType countRamSlots)
    {
        _countRamSlots = countRamSlots;
        return this;
    }

    public IMotherBoardBuilder AddMotherboardFormFactor(MotherboardFormFactorType formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherBoardBuilder AddBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherBoardBuilder AddDdrType(DdrType ddrType)
    {
        _ddrType = ddrType;
        return this;
    }

    public IMotherBoardBuilder AddChipset(IChipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder AddSocketType(SocketType socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherboard Build()
    {
        return new MotherBoard(
            _countSataPorts ?? throw new ArgumentNullException(nameof(_countSataPorts)),
            _countPciELines ?? throw new ArgumentNullException(nameof(_countPciELines)),
            _countRamSlots ?? throw new ArgumentNullException(nameof(_countRamSlots)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _ddrType ?? throw new ArgumentNullException(nameof(_ddrType)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)));
    }
}