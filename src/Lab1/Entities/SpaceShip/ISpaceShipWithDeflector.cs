using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface ISpaceShipWithDeflector : ISpaceShip
{
    public IDeflector Deflector { get; }
}