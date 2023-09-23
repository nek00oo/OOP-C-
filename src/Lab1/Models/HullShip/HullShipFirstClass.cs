using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

public class HullShipFirstClass : HullShipBase
{
    public HullShipFirstClass()
        : base(HullShipClass.First)
    {
        HealthPoints = ConstClass.DamageAsteroidsForHullFirstClass + 1;
    }
}