using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ComponentRepository;

public class RamMemoryRepository
{
    private readonly List<IRamMemory> _ramMemories;

    public RamMemoryRepository()
    {
        _ramMemories = new List<IRamMemory>
        {
            new Models.RamMemory.RamMemory(new CountType(4), new Jedec(new CountType(1600), new CountType(2)), new List<IXmp>() { new Xmp(new CountType(1600), new CountType(2)) }, new RamMemoryFormFactor.Dimm168(), new DdrType.V3(), new CountType(2)),
            new Models.RamMemory.RamMemory(new CountType(16), new Jedec(new CountType(8000), new CountType(1)), new List<IXmp>() { new Xmp(new CountType(8000), new CountType(1)) }, new RamMemoryFormFactor.Dimm184(), new DdrType.V5(), new CountType(1)),
        };
    }

    public IEnumerable<IRamMemory> ReturnRamMemories() => _ramMemories;

    public void AddRamMemory(IRamMemory ramMemory)
    {
        _ramMemories.Add(ramMemory);
    }
}