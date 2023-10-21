using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.SSD;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class SsdRepository
{
    private readonly List<ISsd> _ssds;

    public SsdRepository()
    {
        _ssds = new List<ISsd>
        {
            new Ssd(new CountType(10), new CountType(126), new SpeedType(550), new PortType.Sata()),
            new Ssd(new CountType(20), new CountType(1256), new SpeedType(1000), new PortType.PciE()),
        };
    }

    public IEnumerable<ISsd> ReturnSsds() => _ssds;

    public void AddSsd(ISsd ssd)
    {
        _ssds.Add(ssd);
    }
}