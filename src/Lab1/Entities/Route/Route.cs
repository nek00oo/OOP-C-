using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class Route
{
    private List<SpaceShipBase> _spaceShips;
    private List<SpaceBase> _spaceBases;

    public Route(SpaceBase space, SpaceShipBase spaceShip)
    {
        _spaceBases = new List<SpaceBase> { space };
        _spaceShips = new List<SpaceShipBase> { spaceShip };
    }

    public void AddSpace(SpaceBase space)
    {
        _spaceBases.Add(space);
    }

    public void AddShips(SpaceShipBase spaceShip)
    {
        _spaceShips.Add(spaceShip);
    }

    public void StandardFillingSpaceShips()
    {
        _spaceShips = new List<SpaceShipBase>
        {
            new AvgureShip(),
            new MeredianShip(),
            new PleasureShuttle(),
            new StellaShip(),
            new VaclasShip(),
        };
    }

    public void StandardFillingSpace()
    {
        _spaceBases = new List<SpaceBase>
        {
            new OrdinarySpace(2, new ObstacleAsteroid()),
            new OrdinarySpace(3, new ObstacleMeteorite()),
            new NebulaeNeutrinoParticles(1, new CosmoWhale()),
            new NebulaeIncreasedDensitySpace(4, new ObstacleAntimatterFlares()),
        };
    }

    public void StartRoute()
    {
        foreach (SpaceShipBase spaceShip in _spaceShips)
        {
            NavigateRouteResult navigateRouteResult = new NavigateRouteResult.Success(spaceShip, 0, 0);
            foreach (SpaceBase space in _spaceBases)
            {
                if (space.NavigateSpace(spaceShip, ref navigateRouteResult))
                {
                    if (spaceShip is ISpaceShipWithJumpEngine spaceShipWithJumpEngine)
                    {
                        navigateRouteResult = new NavigateRouteResult.Success(spaceShip, spaceShip.ImpulseEngine.FuelQuantity, spaceShipWithJumpEngine.JumpEngine.FuelQuantity);
                    }
                    else
                    {
                        navigateRouteResult =
                            new NavigateRouteResult.Success(spaceShip, spaceShip.ImpulseEngine.FuelQuantity, 0);
                    }
                }
                else
                {
                    break;
                }
            }

            NavigateRouteResult.ProcessingResults(navigateRouteResult);
        }
    }
}