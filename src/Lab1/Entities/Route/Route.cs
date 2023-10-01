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
            double fuelQuantity = 0;
            NavigateRouteResult navigateRouteResult = new NavigateRouteResult.Success(spaceShip, fuelQuantity);
            foreach (SpaceBase space in _spaceBases)
            {
                if (space.NavigateSpace(spaceShip, out navigateRouteResult, ref fuelQuantity) is false)
                    break;
            }

            NavigateRouteResult.ProcessingResults(navigateRouteResult);
        }
    }
}