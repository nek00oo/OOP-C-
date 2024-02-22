using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentRepository;

public class ProcessorRepository
{
    private readonly List<IProcessor> _processors;

    public ProcessorRepository()
    {
        _processors = new List<IProcessor>
        {
            new Processor(new CountType(3), new CountType(2), new SocketType.Lga775(), new CountType(2400), new CountType(54), new CountType(70)),
            new Processor(new CountType(4), new CountType(8), new SocketType.Am4(), new CountType(3200), new CountType(105), new CountType(150)),
            new Processor(new CountType(3), new CountType(18), new SocketType.Lga2066(), new CountType(2933), new CountType(165), new CountType(200)),
        };
    }

    public IEnumerable<IProcessor> ReturnProcessors() => _processors;

    public void AddProcessor(IProcessor processor)
    {
        _processors.Add(processor);
    }
}