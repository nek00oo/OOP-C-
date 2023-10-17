using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Bios;

public class Bios : IBios
{
    private BiosType _biosType;
    private VersionBios _versionBios;
    private IReadOnlyCollection<IProcessor> _processorsSupport;

    public Bios(
        BiosType biosType,
        VersionBios versionBios,
        IReadOnlyCollection<IProcessor> processorsSupport)
    {
        _biosType = biosType;
        _versionBios = versionBios;
        _processorsSupport = processorsSupport;
    }

    public bool IsProcessorCompatibleWithMotherboard(IProcessor processor)
    {
        throw new System.NotImplementedException();
    }
}