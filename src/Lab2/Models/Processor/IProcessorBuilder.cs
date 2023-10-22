using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IProcessorBuilder
{
    IProcessorBuilder AddCoreFrequency(CountType coreFrequency);
    IProcessorBuilder AddCountCore(CountType countCore);
    IProcessorBuilder AddSocket(SocketType socket);
    IProcessorBuilder AddFrequencyMemory(CountType frequencyMemory);
    IProcessorBuilder AddTdp(CountType tdp);
    IProcessorBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IProcessor Build();
}