using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public class Bios : IBios
{
    public Bios(
        BiosType biosType,
        VersionBios versionBios,
        IReadOnlyCollection<IProcessor> processorsSupport)
    {
        BiosType = biosType;
        VersionBios = versionBios;
        ProcessorsSupport = processorsSupport;
    }

    public BiosType BiosType { get; }
    public VersionBios VersionBios { get; }
    public IReadOnlyCollection<IProcessor> ProcessorsSupport { get; }

    public bool IsProcessorCompatibleWithMotherboard(IProcessor processor)
    {
        return ProcessorsSupport.Contains(processor);
    }
}