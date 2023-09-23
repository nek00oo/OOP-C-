using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipThirdClass : HullShipBase
{
    public HullShipThirdClass()
        : base(HullShipClass.Third)
    {
        HealthPoints = (ConstClass.DamageAsteroidsForHullThirdClass *
                       ConstClass.DamageMeteoritesForHullThirdClass) + 1;
    }
}