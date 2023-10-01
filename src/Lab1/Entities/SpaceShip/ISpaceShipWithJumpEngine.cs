using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface ISpaceShipWithJumpEngine
{
    public IJumpEngine JumpEngine { get; }

    public void UsingFuelJumpEngine(int distance);
}