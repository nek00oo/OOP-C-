using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Bios;

public interface IBios
{
    public BiosType BiosType { get; }
    public VersionBios VersionBios { get; }
    public IReadOnlyCollection<IProcessor> ProcessorsSupport { get; }
    public bool IsProcessorCompatibleWithMotherboard(IProcessor processor);
}