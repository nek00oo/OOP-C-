using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Service.Validator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public class Configurator : IConfigurator
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
    private IList<IValidateResult> _checkList;

    public Configurator()
    {
        _ramMemories = new List<IRamMemory>();
        _externalMemories = new List<IExternalMemory>();
        _checkList = new List<IValidateResult>();
    }

    public IConfigurator AddMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IConfigurator AddProcessor(IProcessor processor)
    {
        _processor = processor;
        return this;
    }

    public IConfigurator AddProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem)
    {
        _processorCoolingSystem = processorCoolingSystem;
        return this;
    }

    public IConfigurator AddRamMemory(IRamMemory ramMemory)
    {
        _ramMemories.Add(ramMemory);
        return this;
    }

    public IConfigurator AddVideoCard(IVideoCard videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IConfigurator AddExternalMemory(IExternalMemory externalMemory)
    {
        _externalMemories.Add(externalMemory);
        return this;
    }

    public IConfigurator AddPowerUnitBuilder(IPowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IConfigurator AddComputerCase(IComputerCase computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IConfigurator AddWiFiAdapter(IWiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public IComputer Build()
    {
        IComputer computer = new Computer(
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _processorCoolingSystem ?? throw new ArgumentNullException(nameof(_processorCoolingSystem)),
            _ramMemories ?? throw new ArgumentNullException(nameof(_ramMemories)),
            _videoCard,
            _externalMemories ?? throw new ArgumentNullException(nameof(_externalMemories)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _wiFiAdapter);

        // TODO сделать подсчёт энергии
        ValidateComputer(computer);

        foreach (IValidateResult validateResult in _checkList)
        {
            if (validateResult is INegativeValidateResult)
                throw new InvalidOperationException($"configuration error : {validateResult}");
        }

        return computer;
    }

    private void ValidateComputer(IComputer computer)
    {
        new ProcessorValidator()
            .SetNext(new ProcessorCoolingSystemValidator())
            .SetNext(new RamMemoryValidator())
            .SetNext(new ComputerCaseValidator())
            .SetNext(new WiFiAdapterValidator())
            .Validate(computer, ref _checkList);
    }
}