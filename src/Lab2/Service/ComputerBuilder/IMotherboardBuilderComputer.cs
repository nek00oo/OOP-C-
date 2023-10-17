using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IMotherboardBuilderComputer
{
    IProcessorBuilderComputer AddMotherboard(IMotherboard motherboard);
}