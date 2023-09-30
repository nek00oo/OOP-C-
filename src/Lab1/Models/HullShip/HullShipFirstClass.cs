namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipFirstClass : HullShipBase
{
    public HullShipFirstClass()
    {
        HealthPoints = ConstClass.DamageAsteroidsForHullFirstClass + 1;
    }
}