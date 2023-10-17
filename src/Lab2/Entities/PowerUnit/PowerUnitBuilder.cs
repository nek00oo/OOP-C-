using System;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerUnit;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private CountType? _maxLoadW;

    public IPowerUnitBuilder AddMaxLoadW(CountType maxLoadW)
    {
        _maxLoadW = maxLoadW;
        return this;
    }

    public IPowerUnit Build()
    {
        return new PowerUnit(_maxLoadW ?? throw new ArgumentNullException(nameof(_maxLoadW)));
    }
}