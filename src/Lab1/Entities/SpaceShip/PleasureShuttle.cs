using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FabricCreateHullShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

public class PleasureShuttle : SpaceShipBase
{
    public PleasureShuttle(bool antineutrinoEmitter = false)
        : base(antineutrinoEmitter, HullShipClass.First, EngineType.C)
    {
    }

    public override bool TakeDamage(IObstaclesBase obstacles, int countObstacles)
    {
        return HullShip.TakeDamage(obstacles, countObstacles) > 0;
    }
}