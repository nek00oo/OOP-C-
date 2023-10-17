using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public class RamMemory : IRamMemory
{
    private CountType _memoryCount;
    private IJedec _jedec;
    private IXMP _xmp;
    private RamMemoryFormFactor _formFactor;
    private DdrType _ddr;

    public RamMemory(
        CountType memoryCount,
        IJedec jedec,
        IXMP xmp,
        RamMemoryFormFactor formFactor,
        DdrType ddr,
        CountType powerConsumptionV)
    {
        _memoryCount = memoryCount;
        _jedec = jedec;
        _xmp = xmp;
        _formFactor = formFactor;
        _ddr = ddr;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType PowerConsumptionV { get; }

    public bool IsRamMemoryCompatibility(IMotherboard motherboard)
    {
        throw new System.NotImplementedException();
    }

    public IRamMemoryBuilder Direct(IRamMemoryBuilder ramMemoryBuilder)
    {
        ramMemoryBuilder.AddMemoryCount(_memoryCount);
        ramMemoryBuilder.AddJedec(_jedec);
        ramMemoryBuilder.AddXmp(_xmp);
        ramMemoryBuilder.AddFormFactor(_formFactor);
        ramMemoryBuilder.AddDdr(_ddr);
        ramMemoryBuilder.AddPowerConsumptionV(PowerConsumptionV);
        return ramMemoryBuilder;
    }
}