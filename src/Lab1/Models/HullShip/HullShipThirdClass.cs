namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : HullShipBase
{
    public HullShipThirdClass()
    {
        HealthPoints = (ConstClass.DamageAsteroidsForHullThirdClass *
                       ConstClass.DamageMeteoritesForHullThirdClass) + 1;
    }
}