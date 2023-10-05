using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
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
        };
        yield return new object[]
        {
            new AvgureShip(),
            new NavigateRouteResult.ShipIsLost(),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest2()
    {
        yield return new object[]
        {
            new VaclasShip(),
            new NavigateRouteResult.CrewKilled(),
        };
        yield return new object[]
        {
            new VaclasShip(photonDeflector: true),
            new NavigateRouteResult.Success(),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest3()
    {
        yield return new object[]
        {
            new VaclasShip(),
            new NavigateRouteResult.ShipIsDestroyed(),
        };
        yield return new object[]
        {
            new AvgureShip(),
            new NavigateRouteResult.Success(),
        };
        yield return new object[]
        {
            new MeredianShip(),
            new NavigateRouteResult.Success(),
        };
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest1))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest2))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult_WhenObstacleAntimatterFlares(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55, new ObstacleAntimatterFlares()));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest3))]
    public void NavigateRouteResult_ReturnNavigateNebulaeNeutrinoParticlesResult_WhenCosmoWhale(SpaceShipBase spaceShip, NavigateRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeNeutrinoParticles(20, new CosmoWhale()));

        // Act
        NavigateRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }
}