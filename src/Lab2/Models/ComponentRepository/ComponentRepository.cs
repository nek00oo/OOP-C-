using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipset;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class ComponentRepository : IComponentRepository
{
    private readonly List<IComputerComponent> _components;

    public ComponentRepository()
    {
        var processor = new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70));
        var processor2 = new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150));
        var processor3 = new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200));
        _components = new List<IComputerComponent>
        {
            new VideoCard(new SizeType(146, 69), new CountType(2), new PciEVersion.V2(), new CountType(954), new CountType(19)),
            new VideoCard(new SizeType(327, 137), new CountType(12), new PciEVersion.V2(), new CountType(2150), new CountType(250)),
            new VideoCard(new SizeType(342, 150), new CountType(24), new PciEVersion.V4(), new CountType(2235), new CountType(300)),
            new ComputerCase(new SizeType(170, 100), new MotherboardFormFactorType[] { new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx(), new MotherboardFormFactorType.MiniItx() }, new SizeType(360, 175)),
            new ComputerCase(new SizeType(360, 200), new MotherboardFormFactorType[] { new MotherboardFormFactorType.EAtx(),  new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx() }, new SizeType(651, 306)),
            new PowerUnit(new CountType(600)),
            new PowerUnit(new CountType(1000)),
            new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70)),
            new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150)),
            new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200)),
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Lga775() }, new CountType(60), new SizeType(60, 60), new CountType(12)),
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Am4(), new SocketType.Lga2066() }, new CountType(250), new SizeType(112, 129), new CountType(12)),
            new Ssd(new CountType(10), new CountType(126), new SpeedType(550)),
            new Ssd(new CountType(20), new CountType(1256), new SpeedType(1000)),
            new HardDrive(new CountType(30), new CountType(300), new SpeedType(10000)),
            new HardDrive(new CountType(30), new CountType(500), new SpeedType(12000)),
            new WiFiAdapter(new WiFiVersion.WiFi4(), new PciEVersion.V2(), new CountType(5)),
            new WiFiAdapter(new WiFiVersion.WiFi5(), new PciEVersion.V4(), new CountType(7)),
            new RamMemory(new CountType(4), new Jedec(new CountType(1600), new CountType(2)), new Xmp(new CountType(1600), new CountType(2)), new RamMemoryFormFactor.Dimm168(), new DdrType.V3(), new CountType(2)),
            new RamMemory(new CountType(16), new Jedec(new CountType(8000), new CountType(1)), new Xmp(new CountType(8000), new CountType(1)), new RamMemoryFormFactor.Dimm184(), new DdrType.V5(), new CountType(1)),
            new MotherBoard(new CountType(4), new CountType(2), new CountType(2), new MotherboardFormFactorType.MicroAtx(), new Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Chipset(true, new CountType(3200)), new SocketType.Am4()),
            new MotherBoard(new CountType(4), new CountType(4), new CountType(4), new MotherboardFormFactorType.EAtx(), new Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Chipset(true, new CountType(3000)), new SocketType.Am4()),
        };
    }

    public void AddComponent(IComputerComponent component)
    {
        _components.Add(component);
    }

    public IEnumerable<IComputerComponent> AllComponents()
    {
        return _components;
    }

    public IEnumerable<IComputerComponent> FilterComponentsByType<T>()
        where T : IComputerComponent
    {
        return _components.Where(component => component is T);
    }
}