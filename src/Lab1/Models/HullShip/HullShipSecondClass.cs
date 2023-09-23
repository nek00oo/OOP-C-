using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipSecondClass : HullShipBase
{
    public HullShipSecondClass()
        : base(HullShipClass.Second)
    {
        HealthPoints = (ConstClass.DamageAsteroidsForHullSecondClass *
                       ConstClass.DamageMeteoritesForHullSecondClass) + 1;
    }
}