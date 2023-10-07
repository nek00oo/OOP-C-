using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface ISpaceShipWithJumpEngine : ISpaceShip
{
    public IJumpEngine JumpEngine { get; }
}