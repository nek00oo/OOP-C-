using Itmo.ObjectOrientedProgramming.Lab2.Models.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;

public interface IMotherboard : IMotherBoardBuilderDirector, IComputerComponent
{
    public CountType CountSataPorts { get; }
    public CountType CountPciELines { get; }
    public CountType CountRamSlots { get; }
    public MotherboardFormFactorType FormFactor { get; }
    public IBios Bios { get; }
    public DdrType DdrType { get; }
    public IChipset Chipset { get; }
    public SocketType Socket { get; }

    public bool ConnectToRamSlots();
    public bool ConnectToPciEPort();
    public bool ConnectToSataPort();
}