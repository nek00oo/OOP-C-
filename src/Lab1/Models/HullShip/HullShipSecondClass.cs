namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    public HullShipSecondClass()
    {
        HealthPoints = (ConstClass.DamageAsteroidsForHullSecondClass *
                       ConstClass.DamageMeteoritesForHullSecondClass) + 1;
    }
}