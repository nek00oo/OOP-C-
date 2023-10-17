using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RamMemory;

public class RamMemoryBuilder : IRamMemoryBuilder
{
    private CountType? _memoryCount;
    private IJedec? _jedec;
    private IXMP? _xmp;
    private RamMemoryFormFactor? _formFactor;
    private DdrType? _ddr;

    public CountType? PowerConsumptionV { get; private set; }

    public IRamMemoryBuilder AddMemoryCount(CountType memoryCount)
    {
        _memoryCount = memoryCount;
        return this;
    }

    public IRamMemoryBuilder AddJedec(IJedec jedec)
    {
        _jedec = jedec;
        return this;
    }

    public IRamMemoryBuilder AddXmp(IXMP xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IRamMemoryBuilder AddFormFactor(RamMemoryFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamMemoryBuilder AddDdr(DdrType ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IRamMemoryBuilder AddPowerConsumptionV(CountType powerConsumptionV)
    {
        PowerConsumptionV = powerConsumptionV;
        return this;
    }

    public IRamMemory Build()
    {
        return new RamMemory(
            _memoryCount ?? throw new ArgumentNullException(nameof(_memoryCount)),
            _jedec ?? throw new ArgumentNullException(nameof(_jedec)),
            _xmp ?? throw new ArgumentNullException(nameof(_xmp)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            PowerConsumptionV ?? throw new ArgumentNullException(nameof(PowerConsumptionV)));
    }
}