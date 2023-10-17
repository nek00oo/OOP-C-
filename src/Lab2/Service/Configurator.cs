using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.HardDrive;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public class Configurator : IConfigurator, IMotherboardBuilderComputer, IProcessorBuilderComputer, IProcessorCoolingSystemBuilderComputer,
    IRamMemoryBuilderComputer, IExternalMemoryBuilderComputerComputer, IPowerUnitBuilderComputer, IComputerCaseBuilderComputer, IVideoCardBuilderComputerComputer
{
    private readonly List<IRamMemory> _ramMemories;
    private readonly List<IExternalMemory> _externalMemories;
    private IMotherboard? _motherboard;
    private IProcessor? _processor;
    private IProcessorCoolingSystem? _processorCoolingSystem;
    private IVideoCard? _videoCard;
    private IPowerUnit? _powerUnit;
    private IComputerCase? _computerCase;
    private IWiFiAdapter? _wiFiAdapter;
    private List<ConfiguratorNegativeResult> _checkList;

    public Configurator()
    {
        _ramMemories = new List<IRamMemory>();
        _externalMemories = new List<IExternalMemory>();
        _checkList = new List<ConfiguratorNegativeResult>();
    }

    public IProcessorBuilderComputer AddMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IProcessorCoolingSystemBuilderComputer AddProcessor(IProcessor processor)
    {
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        if (_motherboard.IsProcessorCompatibility(processor) is false)
            _checkList.Add(new ConfiguratorNegativeResult.ProcessorIsNotCompatible());
        _processor = processor;

        return this;
    }

    public IRamMemoryBuilderComputer AddProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem)
    {
        if (_processor == null)
            throw new InvalidOperationException("The processor is not installed");
        if (_processor.IsCoolingSystemCompatibility(processorCoolingSystem) is false)
            _checkList.Add(new ConfiguratorNegativeResult.CoolingSystemIsNotCompatible());

        // комментарий о гарантии (сделать)
        _processorCoolingSystem = processorCoolingSystem;

        return this;
    }

    public IVideoCardOrExternalMemoryBuilderComputer AddRamMemory(IRamMemory ramMemory)
    {
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        if (ramMemory.IsRamMemoryCompatibility(_motherboard) is false)
            _checkList.Add(new ConfiguratorNegativeResult.RamIsNotCompatible());
        _ramMemories.Add(ramMemory);

        return this;
    }

    public IExternalMemoryBuilderComputerComputer AddVideoCard(IVideoCard videoCard)
    {
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        if (videoCard.IsVideoCardCompatibility(_motherboard) is false)
            _checkList.Add(new ConfiguratorNegativeResult.VideoCardIsNotCompatible());
        _videoCard = videoCard;

        return this;
    }

    public IPowerUnitBuilderComputer AddEExternalMemory(IExternalMemory externalMemory)
    {
        if (_videoCard == null && _processor?.VideoCore == false)
            throw new InvalidOperationException("The processor does not have a video core, you need to install a video card");
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        if (externalMemory is IHardDrive)
            _externalMemories.Add(externalMemory);
        if (externalMemory is ISsd ssd)
        {
            _externalMemories.Add(ssd);
            if (ssd.IsConnectMotherBoard(_motherboard) is false)
                _checkList.Add(new ConfiguratorNegativeResult.SsdIsNotCompatible());
        }

        return this;
    }

    public IComputerCaseBuilderComputer AddPowerUnitBuilder(IPowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IConfigurator AddComputerCase(IComputerCase computerCase)
    {
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        _computerCase = computerCase;
        if ((_computerCase.IsComputerCaseCompatibility(_motherboard) is false) ||
            (_videoCard != null && _computerCase.IsComputerCaseCompatibility(_videoCard) is false))
            _checkList.Add(new ConfiguratorNegativeResult.ComputerCaseIsNotCompatible());

        return this;
    }

    public IConfigurator AddWiFiAdapter(IWiFiAdapter wiFiAdapter)
    {
        if (_motherboard == null)
            throw new InvalidOperationException("The motherboard is not installed");
        _wiFiAdapter = wiFiAdapter;
        if (_wiFiAdapter.IsWiFiCompatibility(_motherboard) is false)
            _checkList.Add(new ConfiguratorNegativeResult.WiFiAdapterIsNotCompatible());
        _wiFiAdapter = wiFiAdapter;

        return this;
    }

    public IComputer Build()
    {
        if (_powerUnit != null && _powerUnit.TotalSystemConsumption(_ramMemories, _externalMemories, _processor, _processorCoolingSystem))
        {
            // переделать эту функцию, чтобы мб она принимала один параметр IConsumeEnergy и внутри себя как-то складывала
        }

        return new Computer(
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _processorCoolingSystem ?? throw new ArgumentNullException(nameof(_processorCoolingSystem)),
            _ramMemories ?? throw new ArgumentNullException(nameof(_ramMemories)),
            _videoCard,
            _externalMemories ?? throw new ArgumentNullException(nameof(_externalMemories)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _wiFiAdapter);
    }
}