using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

public class MotherBoard : IMotherboard
{
    private CountType _countSataPorts;
    private CountType _countPciELines;
    private CountType _countRamSlots;
    private MotherboardFormFactorType _formFactor;
    private IBios _bios;
    private DdrType _ddrType;
    private IChipset _chipset;
    private SocketType _socket;

    public MotherBoard(
        CountType countSataPorts,
        CountType countPciELines,
        CountType countRamSlots,
        MotherboardFormFactorType formFactor,
        IBios bios,
        DdrType ddrType,
        IChipset chipset,
        SocketType socket)
    {
        _countSataPorts = countSataPorts;
        _countPciELines = countPciELines;
        _countRamSlots = countRamSlots;
        _formFactor = formFactor;
        _bios = bios;
        _ddrType = ddrType;
        _chipset = chipset;
        _socket = socket;
    }

    public bool IsProcessorCompatibility(IProcessor processor)
    {
        throw new System.NotImplementedException();
    }

    public IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder)
    {
        motherBoardBuilder.AddCountSataPorts(_countSataPorts);
        motherBoardBuilder.AddCountPciELines(_countPciELines);
        motherBoardBuilder.AddCountRamSlots(_countRamSlots);
        motherBoardBuilder.AddMotherboardFormFactor(_formFactor);
        motherBoardBuilder.AddBios(_bios);
        motherBoardBuilder.AddDdrType(_ddrType);
        motherBoardBuilder.AddChipset(_chipset);
        motherBoardBuilder.AddSocketType(_socket);
        return motherBoardBuilder;
    }
}