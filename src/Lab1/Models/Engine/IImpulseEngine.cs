using Itmo.ObjectOrientedProgramming.Lab1.Service.FlySpaceResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IImpulseEngine
{
    public FlyResult FlyingSpace(int distance, double speedEffectAe = 0);
}