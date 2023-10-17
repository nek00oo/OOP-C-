using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder AddMaxSizeTypeVideoCard(SizeType maxSizeTypeVideoCard);
    IComputerCaseBuilder AddMotherboardFormFactorSupported(MotherboardFormFactorType motherboardFormFactorSupported);
    IComputerCaseBuilder AddCaseSizeType(SizeType caseSizeType);
    IComputerCase Build();
}