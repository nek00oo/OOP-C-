using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Result;

public sealed record IsNotCompability<TComponentFirst, TComponentSecond>(TComponentFirst ComputerComponentFirst, TComponentSecond ComputerComponentSecond) : INegativeValidateResult
    where TComponentFirst : IComputerComponent
    where TComponentSecond : IComputerComponent;