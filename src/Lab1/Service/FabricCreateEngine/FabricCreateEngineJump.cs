using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateEngine;

public static class FabricCreateEngineJump
{
    public static JumpEngine CreateJumpEngine(EngineType engineType)
    {
        switch (engineType)
        {
            case EngineType.Alpha:
                return new JumpEngineAlpha();
            case EngineType.Omega:
                return new JumpEngineOmega();
            case EngineType.Gamma:
                return new JumpEngineGamma();
            default:
                throw new InvalidOperationException("This type of jump engine does not exist");
        }
    }
}