using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class ProcessorCoolingSystemRepository
{
    private readonly List<IProcessorCoolingSystem> _coolingSystems;

    public ProcessorCoolingSystemRepository()
    {
        _coolingSystems = new List<IProcessorCoolingSystem>
        {
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Lga775() }, new CountType(60), new SizeType(60, 60), new CountType(12)),
            new ProcessorCoolingSystem(new List<SocketType> { new SocketType.Am4(), new SocketType.Lga2066() }, new CountType(250), new SizeType(112, 129), new CountType(12)),
        };
    }

    public IEnumerable<IProcessorCoolingSystem> ReturnProcessorCoolingSystems() => _coolingSystems;

    public void AddProcessorCoolingSystem(IProcessorCoolingSystem coolingSystem)
    {
        _coolingSystems.Add(coolingSystem);
    }
}