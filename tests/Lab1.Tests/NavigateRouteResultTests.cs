using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class NavigateRouteResultTests
{
    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest1()
    {
        yield return new object[]
        {
            new PleasureShuttle(),
            new NavigateRouteResult.ShipIsLost(),
            new FuelExchange(5, 7),
        };
        yield return new object[]
        {
            new AvgureShip(),
            new NavigateRouteResult.ShipIsLost(),
            new FuelExchange(1, 2),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest2()
    {
        yield return new object[]
        {
            new VaclasShip(),
            new NavigateRouteResult.CrewKilled(),
            new FuelExchange(10, 20),
        };
        yield return new object[]
        {
            new VaclasShip(photonDeflector: true),
            new NavigateRouteResult.SuccessPriceAndTimeForRoute(3025000, 1),
            new FuelExchange(10, 20),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest3()
    {
        yield return new object[]
        {
            new VaclasShip(),
            new NavigateRouteResult.ShipIsDestroyed(),
            new FuelExchange(10, 20),
        };
        yield return new object[]
        {
            new AvgureShip(),
            new NavigateRouteResult.SuccessPriceAndTimeForRoute(22261.97, 1.25),
            new FuelExchange(2, 7),
        };
        yield return new object[]
        {
            new MeredianShip(),
            new NavigateRouteResult.SuccessPriceAndTimeForRoute(11130.99, 1.25),
            new FuelExchange(1, 5),
        };
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest1))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult, IFuelExchange fuelExchange)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip, fuelExchange);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest2))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult_WhenObstacleAntimatterFlares(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult, IFuelExchange fuelExchange)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55, new ObstacleAntimatterFlares()));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip, fuelExchange);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest3))]
    public void NavigateRouteResult_ReturnNavigateNebulaeNeutrinoParticlesResult_WhenCosmoWhale(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult, IFuelExchange fuelExchange)
    {
        // Arrange
        var route = new Route(new NebulaeNeutrinoParticles(5, new CosmoWhale()));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip, fuelExchange);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }
}