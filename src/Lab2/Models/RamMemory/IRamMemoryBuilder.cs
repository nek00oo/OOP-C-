using Itmo.ObjectOrientedProgramming.Lab2.Models.Jedec;
using Itmo.ObjectOrientedProgramming.Lab2.Models.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.RamMemory;

public interface IRamMemoryBuilder
{
    IRamMemoryBuilder AddMemoryCount(CountType memoryCount);
    IRamMemoryBuilder AddJedec(IJedec jedec);
    IRamMemoryBuilder AddXmp(IXmp xmp);
    IRamMemoryBuilder AddFormFactor(RamMemoryFormFactor formFactor);
    IRamMemoryBuilder AddDdr(DdrType ddr);
    IRamMemoryBuilder AddPowerConsumptionV(CountType powerConsumptionV);
    IRamMemory Build();
}