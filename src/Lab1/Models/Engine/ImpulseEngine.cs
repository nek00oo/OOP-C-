namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public abstract class ImpulseEngine : EngineBase
{
    protected ImpulseEngine(EngineType engineTypeImpulse)
        : base(engineTypeImpulse)
    {
    }
}