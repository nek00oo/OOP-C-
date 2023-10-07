using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface IJumpEngineHolder
{
    public IJumpEngine JumpEngine { get; }

    public double UsingFuelJumpEngine(int distance);
}