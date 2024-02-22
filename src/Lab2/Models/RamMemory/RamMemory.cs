using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;

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
            return new SuccessValidateResult.SuccessCompability();

        return new IsNotCompability<IRamMemory, IMotherboard>(this, motherboard);
    }

    public IRamMemoryBuilder Direct(IRamMemoryBuilder ramMemoryBuilder)
    {
        foreach (IXmp xmp in XmpProfiles)
        {
            ramMemoryBuilder.AddXmp(xmp);
        }

        ramMemoryBuilder.AddMemoryCount(MemoryCount)
            .AddJedec(Jedec)
            .AddFormFactor(FormFactor)
            .AddDdr(Ddr)
            .AddPowerConsumptionV(PowerConsumptionV);
        return ramMemoryBuilder;
    }
}