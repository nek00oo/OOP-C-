using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class ComputerCaseRepository
{
    private readonly List<IComputerCase> _computerCases;

    public ComputerCaseRepository()
    {
        _computerCases = new List<IComputerCase>
        {
            new ComputerCase(new SizeType(170, 100), new MotherboardFormFactorType[] { new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx(), new MotherboardFormFactorType.MiniItx() }, new SizeType(360, 175)),
            new ComputerCase(new SizeType(360, 200), new MotherboardFormFactorType[] { new MotherboardFormFactorType.EAtx(),  new MotherboardFormFactorType.StandardAtx(), new MotherboardFormFactorType.MicroAtx() }, new SizeType(651, 306)),
        };
    }

    public IEnumerable<IComputerCase> ReturnComputerCases() => _computerCases;

    public void AddComputerCase(IComputerCase computerCase)
    {
        _computerCases.Add(computerCase);
    }
}