using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

public static class FabricCreateHullShip
{
    public static HullShipBase CreateHullShip(HullShipClass engineType)
    {
        switch (engineType)
        {
            case HullShipClass.First:
                return new HullShipFirstClass();
            case HullShipClass.Second:
                return new HullShipSecondClass();
            case HullShipClass.Third:
                return new HullShipThirdClass();
            default:
                throw new InvalidOperationException("This type of impulse engine does not exist");
        }
    }
}