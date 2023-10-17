using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer : IComputer
{
    private IMotherboard _motherboard;
    private IProcessor _processor;
    private IProcessorCoolingSystem _processorCoolingSystem;
    private IReadOnlyCollection<IRamMemory> _ramMemories;
    private IReadOnlyCollection<IExternalMemory> _externalMemories;
    private IPowerUnit _powerUnit;
    private IComputerCase _computerCase;
    private IVideoCard? _videoCard;
    private IWiFiAdapter? _wiFiAdapter;

    public Computer(
        IMotherboard motherboard,
        IProcessor processor,
        IProcessorCoolingSystem processorCoolingSystem,
        IReadOnlyCollection<IRamMemory> ramMemories,
        IVideoCard? videoCard,
        IReadOnlyCollection<IExternalMemory> externalMemories,
        IPowerUnit powerUnit,
        IComputerCase computerCase,
        IWiFiAdapter? wiFiAdapter)
    {
        _motherboard = motherboard;
        _processor = processor;
        _processorCoolingSystem = processorCoolingSystem;
        _ramMemories = ramMemories;
        _videoCard = videoCard;
        _externalMemories = externalMemories;
        _powerUnit = powerUnit;
        _computerCase = computerCase;
        _wiFiAdapter = wiFiAdapter;
    }
}