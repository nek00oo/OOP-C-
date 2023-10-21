using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class PowerUnitRepository
{
    private readonly List<IPowerUnit> _powerUnits;

    public PowerUnitRepository()
    {
        _powerUnits = new List<IPowerUnit>
        {
            new PowerUnit(new CountType(600)),
            new PowerUnit(new CountType(1000)),
        };
    }

    public IEnumerable<IPowerUnit> ReturnPowerUnits() => _powerUnits;

    public void AddPowerUnit(IPowerUnit powerUnit)
    {
        _powerUnits.Add(powerUnit);
    }
}