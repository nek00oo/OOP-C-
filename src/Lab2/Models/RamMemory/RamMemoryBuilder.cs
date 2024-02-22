using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;

public class RamMemoryBuilder : IRamMemoryBuilder
{
    private readonly List<IXmp> _xmpProfiles;
    private CountType? _memoryCount;
    private IJedec? _jedec;
    private RamMemoryFormFactor? _formFactor;
    private DdrType? _ddr;

    public RamMemoryBuilder()
    {
        _xmpProfiles = new List<IXmp>();
    }

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

    public IRamMemoryBuilder AddXmp(IXmp xmp)
    {
        _xmpProfiles.Add(xmp);
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
        return new Models.RamMemory.RamMemory(
            _memoryCount ?? throw new ArgumentNullException(nameof(_memoryCount)),
            _jedec ?? throw new ArgumentNullException(nameof(_jedec)),
            _xmpProfiles ?? throw new ArgumentNullException(nameof(_xmpProfiles)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            PowerConsumptionV ?? throw new ArgumentNullException(nameof(PowerConsumptionV)));
    }
}