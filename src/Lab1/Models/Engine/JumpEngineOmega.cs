using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : JumpEngine
{
    public JumpEngineOmega()
        : base(EngineType.Omega)
    {
    }

    public override double CalculateFuelRequired(double fuelQuantity, int distance)
    {
       return fuelQuantity - (FuelConsumptionAe * Math.Log10(distance));
    }
}