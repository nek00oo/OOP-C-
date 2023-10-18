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

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public interface IComponentRepository
{
    public void AddComponent(IComputerComponent component);
    public IEnumerable<IMotherboard> GetMotherboards();
    public IEnumerable<IProcessor> GetProcessors();
    public IEnumerable<IProcessorCoolingSystem> GetProcessorCoolingSystems();
    public IEnumerable<ISsd> GetSsds();
    public IEnumerable<IHardDrive> GetHardDrives();
    public IEnumerable<IRamMemory> GetRamMemories();
    public IEnumerable<IVideoCard> GetVideoCards();
    public IEnumerable<IPowerUnit> GetPowerUnits();
    public IEnumerable<IComputerCase> GetComputerCases();
    public IEnumerable<IWiFiAdapter> GetWiFiAdapters();
}