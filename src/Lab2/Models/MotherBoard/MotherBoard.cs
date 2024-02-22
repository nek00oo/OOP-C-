using Itmo.ObjectOrientedProgramming.Lab2.Models.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;

public class MotherBoard : IMotherboard
{
    internal MotherBoard(
        CountType countSataPorts,
        CountType countPciELines,
        CountType countRamSlots,
        MotherboardFormFactorType formFactor,
        IBios bios,
        DdrType ddrType,
        IChipset chipset,
        SocketType socket)
    {
        CountSataPorts = countSataPorts;
        CountPciELines = countPciELines;
        CountRamSlots = countRamSlots;
        FormFactor = formFactor;
        Bios = bios;
        DdrType = ddrType;
        Chipset = chipset;
        Socket = socket;
    }

    public CountType CountSataPorts { get; }
    public CountType CountPciELines { get; }
    public CountType CountRamSlots { get; }
    public MotherboardFormFactorType FormFactor { get; }
    public IBios Bios { get; }
    public DdrType DdrType { get; }
    public IChipset Chipset { get; }
    public SocketType Socket { get; }

    public bool ConnectToRamSlots()
    {
        if (CountRamSlots.Count == 0)
            return false;
        CountRamSlots.Count--;
        return true;
    }

    public bool ConnectToPciEPort()
    {
        if (CountPciELines.Count == 0)
            return false;
        CountPciELines.Count--;
        return true;
    }

    public bool ConnectToSataPort()
    {
        if (CountSataPorts.Count == 0)
            return false;
        CountSataPorts.Count--;
        return true;
    }

    public IMotherBoardBuilder Direct(IMotherBoardBuilder motherBoardBuilder)
    {
        motherBoardBuilder.AddCountSataPorts(CountSataPorts)
            .AddCountPciELines(CountPciELines)
            .AddCountRamSlots(CountRamSlots)
            .AddMotherboardFormFactor(FormFactor)
            .AddBios(Bios)
            .AddDdrType(DdrType)
            .AddChipset(Chipset)
            .AddSocketType(Socket);
        return motherBoardBuilder;
    }
}