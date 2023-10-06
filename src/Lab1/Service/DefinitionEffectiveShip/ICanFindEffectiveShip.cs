using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.DefinitionEffectiveShip;

public interface ICanFindEffectiveShip
{
    public SpaceShipBase? FindEffectiveShip();
}