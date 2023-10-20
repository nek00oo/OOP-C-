using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public class RamMemory : IRamMemory
{
    internal RamMemory(
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

    public IValidateResult IsRamMemoryCompatibility(IMotherboard motherboard)
    {
        bool xmpProfileSupport = false;
        foreach (IXmp xmp in XmpProfiles)
        {
            if (motherboard.Chipset.Frequency.Count <= xmp.FrequencyChip.Count)
                xmpProfileSupport = true;
        }

        if (Ddr == motherboard.DdrType && xmpProfileSupport && motherboard.ConnectToRamSlots())
            return new SuccessValidateResult.RamMemoryAndMotherboardCompability();

        return new NegativeValidateResult.RamMemoryAndMotherboardIsNotCompability();
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