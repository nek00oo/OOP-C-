using System;
using System.Collections.Generic;
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
    private readonly List<IMotherboard> _motherboards;
    private readonly List<IProcessor> _processors;
    private readonly List<IProcessorCoolingSystem> _coolingSystems;
    private readonly List<ISsd> _ssds;
    private readonly List<IHardDrive> _hardDrives;
    private readonly List<IRamMemory> _ramMemories;
    private readonly List<IVideoCard> _videoCards;
    private readonly List<IPowerUnit> _powerUnits;
    private readonly List<IComputerCase> _computerCases;
    private readonly List<IWiFiAdapter> _wiFiAdapters;

    public ComponentRepository()
    {
        var processor = new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70));
        var processor2 = new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150));
        var processor3 = new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200));
        _motherboards = new List<IMotherboard>
        {
            new MotherBoard(new CountType(4), new CountType(2), new CountType(2), new MotherboardFormFactorType.MicroAtx(), new Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Chipset(true, new CountType(3200)), new SocketType.Am4()),
            new MotherBoard(new CountType(4), new CountType(4), new CountType(4), new MotherboardFormFactorType.EAtx(), new Bios(new BiosType.IntelBios(), new VersionBios.F3(), new List<IProcessor>() { processor, processor2, processor3 }), new DdrType.V5(), new Chipset(true, new CountType(3000)), new SocketType.Am4()),
        };
        _processors = new List<IProcessor>
        {
            new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70)),
            new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150)),
            new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200)),
        };
        _coolingSystems = new List<IProcessorCoolingSystem>
        {
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Lga775() }, new CountType(60), new SizeType(60, 60), new CountType(12)),
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Am4(), new SocketType.Lga2066() }, new CountType(250), new SizeType(112, 129), new CountType(12)),
        };
        _ssds = new List<ISsd>
        {
            new Ssd(new CountType(10), new CountType(126), new SpeedType(550), new PortType.Sata()),
            new Ssd(new CountType(20), new CountType(1256), new SpeedType(1000), new PortType.PciE()),
        };
        _hardDrives = new List<IHardDrive>
        {
            new HardDrive(new CountType(30), new CountType(300), new SpeedType(10000)),
            new HardDrive(new CountType(30), new CountType(500), new SpeedType(12000)),
        };
        _ramMemories = new List<IRamMemory>
        {
            new RamMemory(new CountType(4), new Jedec(new CountType(1600), new CountType(2)), new List<IXmp>() { new Xmp(new CountType(1600), new CountType(2)) }, new RamMemoryFormFactor.Dimm168(), new DdrType.V3(), new CountType(2)),
            new RamMemory(new CountType(16), new Jedec(new CountType(8000), new CountType(1)), new List<IXmp>() { new Xmp(new CountType(8000), new CountType(1)) }, new RamMemoryFormFactor.Dimm184(), new DdrType.V5(), new CountType(1)),
        };
        _videoCards = new List<IVideoCard>
        {
            new VideoCard(new SizeType(146, 69), new CountType(2), new PciEVersion.V2(), new CountType(954), new CountType(19)),
            new VideoCard(new SizeType(327, 137), new CountType(12), new PciEVersion.V2(), new CountType(2150), new CountType(250)),
            new VideoCard(new SizeType(342, 150), new CountType(24), new PciEVersion.V4(), new CountType(2235), new CountType(300)),
        };
        _powerUnits = new List<IPowerUnit>
        {
            new PowerUnit(new CountType(600)),
            new PowerUnit(new CountType(1000)),
        };
        _computerCases = new List<IComputerCase>
        {
            new ComputerCase(new SizeType(170, 100), new MotherboardFormFactorType[] { new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx(), new MotherboardFormFactorType.MiniItx() }, new SizeType(360, 175)),
            new ComputerCase(new SizeType(360, 200), new MotherboardFormFactorType[] { new MotherboardFormFactorType.EAtx(),  new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx() }, new SizeType(651, 306)),
        };
        _wiFiAdapters = new List<IWiFiAdapter>
        {
            new WiFiAdapter(new WiFiVersion.WiFi4(), new PciEVersion.V2(), new CountType(5)),
            new WiFiAdapter(new WiFiVersion.WiFi5(), new PciEVersion.V4(), new CountType(7)),
        };
    }

    public void AddComponent(IComputerComponent component)
    {
        switch (component)
        {
            case IMotherboard motherboard:
                _motherboards.Add(motherboard);
                break;
            case IProcessor processor:
                _processors.Add(processor);
                break;
            case IProcessorCoolingSystem coolingSystem:
                _coolingSystems.Add(coolingSystem);
                break;
            case ISsd ssd:
                _ssds.Add(ssd);
                break;
            case IHardDrive hardDrive:
                _hardDrives.Add(hardDrive);
                break;
            case IRamMemory ramMemory:
                _ramMemories.Add(ramMemory);
                break;
            case IVideoCard videoCard:
                _videoCards.Add(videoCard);
                break;
            case IPowerUnit powerUnit:
                _powerUnits.Add(powerUnit);
                break;
            case IComputerCase computerCase:
                _computerCases.Add(computerCase);
                break;
            case IWiFiAdapter wiFiAdapter:
                _wiFiAdapters.Add(wiFiAdapter);
                break;
            default:
                throw new InvalidOperationException("non-existent component type");
        }
    }

    public IEnumerable<IMotherboard> GetMotherboards() => _motherboards;

    public IEnumerable<IProcessor> GetProcessors() => _processors;

    public IEnumerable<IProcessorCoolingSystem> GetProcessorCoolingSystems() => _coolingSystems;

    public IEnumerable<ISsd> GetSsds() => _ssds;

    public IEnumerable<IHardDrive> GetHardDrives() => _hardDrives;

    public IEnumerable<IRamMemory> GetRamMemories() => _ramMemories;

    public IEnumerable<IVideoCard> GetVideoCards() => _videoCards;

    public IEnumerable<IPowerUnit> GetPowerUnits() => _powerUnits;

    public IEnumerable<IComputerCase> GetComputerCases() => _computerCases;

    public IEnumerable<IWiFiAdapter> GetWiFiAdapters() => _wiFiAdapters;
}