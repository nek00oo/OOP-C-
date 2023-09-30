using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : IJumpEngine
{
    public int FuelConsumptionAe { get; } = 50;
    public int JumpRange { get; } = 125;

    public double CalculateFuelRequired(int distance)
    {
       return FuelConsumptionAe * distance * Math.Log10(distance);
    }
}