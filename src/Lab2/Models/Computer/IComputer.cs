using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;

public interface IComputer : IComputerBuilderDirector
{
    public IMotherboard Motherboard { get; }
    public IProcessor Processor { get; }
    public IProcessorCoolingSystem ProcessorCoolingSystem { get; }
    public IReadOnlyCollection<IRamMemory> RamMemories { get; }
    public IReadOnlyCollection<IExternalMemory> ExternalMemories { get; }
    public IPowerUnit PowerUnit { get; }
    public IComputerCase ComputerCase { get; }
    public IVideoCard? VideoCard { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}