using Itmo.ObjectOrientedProgramming.Lab2.Models.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder AddCountSataPorts(CountType countSataPorts);
    IMotherBoardBuilder AddCountPciELines(CountType countPciELines);
    IMotherBoardBuilder AddCountRamSlots(CountType countRamSlots);
    IMotherBoardBuilder AddMotherboardFormFactor(MotherboardFormFactorType formFactor);
    IMotherBoardBuilder AddBios(IBios bios);
    IMotherBoardBuilder AddDdrType(DdrType ddrType);
    IMotherBoardBuilder AddChipset(IChipset chipset);
    IMotherBoardBuilder AddSocketType(SocketType socket);
    IMotherboard Build();
}