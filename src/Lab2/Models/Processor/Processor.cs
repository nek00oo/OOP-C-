using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Result;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Processor : IProcessor, IEquatable<Processor>
{
    internal Processor(
        CountType coreFrequency,
        CountType countCore,
        SocketType socket,
        CountType frequencyMemory,
        CountType tdp,
        CountType powerConsumptionV)
    {
        CoreFrequency = coreFrequency;
        CountCore = countCore;
        Socket = socket;
        FrequencyMemory = frequencyMemory;
        Tdp = tdp;
        PowerConsumptionV = powerConsumptionV;
    }

    public CountType CoreFrequency { get; }
    public CountType CountCore { get; }
    public SocketType Socket { get; }
    public CountType FrequencyMemory { get; }
    public CountType Tdp { get; }

    public CountType PowerConsumptionV { get; }

    public IValidateResult IsProcessorCompatibility(IMotherboard motherboard)
    {
        if (Socket == motherboard.Socket && motherboard.Bios.IsProcessorCompatibleWithMotherboard(this))
            return new SuccessValidateResult.SuccessCompability();
        return new IsNotCompability<IProcessor, IMotherboard>(this, motherboard);
    }

    public IProcessorBuilder Direct(IProcessorBuilder processorBuilder)
    {
        processorBuilder.AddCoreFrequency(CoreFrequency)
            .AddCountCore(CountCore)
            .AddSocket(Socket)
            .AddFrequencyMemory(FrequencyMemory)
            .AddTdp(Tdp)
            .AddPowerConsumptionV(PowerConsumptionV);
        return processorBuilder;
    }

    public bool Equals(Processor? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return CoreFrequency.Equals(other.CoreFrequency) && CountCore.Equals(other.CountCore) && Socket.Equals(other.Socket) && FrequencyMemory.Equals(other.FrequencyMemory) && Tdp.Equals(other.Tdp) && PowerConsumptionV.Equals(other.PowerConsumptionV);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Processor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CoreFrequency, CountCore, Socket, FrequencyMemory, Tdp, PowerConsumptionV);
    }
}