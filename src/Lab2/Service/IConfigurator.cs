using Itmo.ObjectOrientedProgramming.Lab2.Entities.Computer;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ProcessorCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Models.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.WiFiAdapter;

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