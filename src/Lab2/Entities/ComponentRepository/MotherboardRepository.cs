using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentRepository;

public class MotherboardRepository
{
    private readonly List<IMotherboard> _motherboards;

    public MotherboardRepository()
    {
        var processor = new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70));
        var processor2 = new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150));
        var processor3 = new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200));
        _motherboards = new List<IMotherboard>
        {
            new Models.MotherBoard.MotherBoard(new CountType(4), new CountType(2), new CountType(2), new MotherboardFormFactorType.MicroAtx(), new Models.Bios.Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Models.Chipset.Chipset(true, new CountType(3200)), new SocketType.Am4()),
            new Models.MotherBoard.MotherBoard(new CountType(4), new CountType(4), new CountType(4), new MotherboardFormFactorType.EAtx(), new Models.Bios.Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Models.Chipset.Chipset(true, new CountType(3000)), new SocketType.Am4()),
        };
    }

    public IEnumerable<IMotherboard> ReturnMotherboards() => _motherboards;

    public void AddComponent(IMotherboard motherboard)
    {
        _motherboards.Add(motherboard);
    }
}