using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ProcessorCoolingSystem;

public interface IProcessorCoolingSystemBuilder
{
    IProcessorCoolingSystemBuilder AddSocket(SocketType socket);
    IProcessorCoolingSystemBuilder AddTdp(CountType tdp);
    IProcessorCoolingSystemBuilder AddSize(SizeType size);
    IProcessorCoolingSystemBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IProcessorCoolingSystem Build();
}