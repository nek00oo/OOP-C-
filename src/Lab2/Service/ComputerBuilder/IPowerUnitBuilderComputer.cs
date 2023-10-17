using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComputerBuilder;

public interface IPowerUnitBuilderComputer
{
    IComputerCaseBuilderComputer AddPowerUnitBuilder(IPowerUnit powerUnit);
}