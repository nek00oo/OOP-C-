using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;

public static class FabricCreateEngineImpulse
{
    public static ImpulseEngine CreateEngine(EngineType engineType)
    {
        switch (engineType)
        {
            case EngineType.C:
                return new ImpulseEngineC();
            case EngineType.E:
                return new ImpulseEngineE();
            default:
                throw new InvalidOperationException("This type of impulse engine does not exist");
        }
    }
}