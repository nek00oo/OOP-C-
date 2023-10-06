using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public interface IHaveDeflector
{
    public DeflectorBase Deflector { get; }
}