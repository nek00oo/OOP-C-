using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public interface IConfigurator
{
    public IConfigurator AddMotherboard(IMotherboard motherboard);

    public IConfigurator AddProcessor(IProcessor processor);

    public IConfigurator AddProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem);

    public IConfigurator AddRamMemory(IRamMemory ramMemory);

    public IConfigurator AddVideoCard(IVideoCard videoCard);

    public IConfigurator AddExternalMemory(IExternalMemory externalMemory);

    public IConfigurator AddPowerUnitBuilder(IPowerUnit powerUnit);
    public IConfigurator AddComputerCase(IComputerCase computerCase);
    IConfigurator AddWiFiAdapter(IWiFiAdapter wiFiAdapter);
    IComputer Build();
}