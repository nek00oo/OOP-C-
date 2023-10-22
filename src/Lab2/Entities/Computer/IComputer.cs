using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;

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