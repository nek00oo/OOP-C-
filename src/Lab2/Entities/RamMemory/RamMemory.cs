using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public class RamMemory : IRamMemory
{
    public RamMemory(
        CountType memoryCount,
        IJedec jedec,
        IReadOnlyCollection<IXmp> xmpProfiles,
        RamMemoryFormFactor formFactor,
        DdrType ddr,
        CountType powerConsumptionV)
    {
        MemoryCount = memoryCount;
        Jedec = jedec;
        XmpProfiles = xmpProfiles;
        this.FormFactor = formFactor;
        Ddr = ddr;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType MemoryCount { get; }
    public IJedec Jedec { get; }
    public IReadOnlyCollection<IXmp> XmpProfiles { get; }
    public RamMemoryFormFactor FormFactor { get; }
    public DdrType Ddr { get; }
    public CountType PowerConsumptionV { get; }

    public bool IsRamMemoryCompatibility(IMotherboard motherboard)
    {
        return Ddr == motherboard.DdrType && motherboard.ConnectToRamSlots();
    }

    public IRamMemoryBuilder Direct(IRamMemoryBuilder ramMemoryBuilder)
    {
        foreach (IXmp xmp in XmpProfiles)
        {
            ramMemoryBuilder.AddXmp(xmp);
        }

        ramMemoryBuilder.AddMemoryCount(MemoryCount);
        ramMemoryBuilder.AddJedec(Jedec);
        ramMemoryBuilder.AddFormFactor(FormFactor);
        ramMemoryBuilder.AddDdr(Ddr);
        ramMemoryBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return ramMemoryBuilder;
    }
}