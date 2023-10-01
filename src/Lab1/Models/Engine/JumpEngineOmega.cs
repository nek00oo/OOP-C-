using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : IJumpEngine
{
    public int FuelConsumptionAe { get; } = 50;
    public int JumpRange { get; } = 125;
    public double FuelQuantity { get; private set; }

    public void CalculateFuelRequired(int distance)
    {
       FuelQuantity += FuelConsumptionAe * distance * Math.Log2(distance);
    }
}