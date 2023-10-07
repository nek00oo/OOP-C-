using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.RouteResult;
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
        IDeflector deflectorThirdClassForAvgure1 = new DeflectorThirdClass();
        yield return new object[]
        {
            new AvgureShip(deflectorThirdClassForAvgure1),
            new NavigateRouteResult.ShipIsLost(),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest2()
    {
        IDeflector deflectorFirstClassForVaclas1 = new DeflectorFirstClass();
        yield return new object[]
        {
            new VaclasShip(deflectorFirstClassForVaclas1),
            new ObstacleCollisionResult.CrewKilled(),
        };
        IDeflector deflectorFirstClassForVaclas2 = new DeflectorFirstClass();
        deflectorFirstClassForVaclas2 = new PhotonDeflector(deflectorFirstClassForVaclas2);
        yield return new object[]
        {
            new VaclasShip(deflectorFirstClassForVaclas2),
            new NavigateRouteResult.Success(1),
        };
    }

    public static IEnumerable<object[]> GetShipAndNavigateRouteResultTest3()
    {
        IDeflector deflectorFirstClassForVaclas1 = new DeflectorFirstClass();
        yield return new object[]
        {
            new VaclasShip(deflectorFirstClassForVaclas1),
            new ObstacleCollisionResult.ShipIsDestroyed(),
        };
        IDeflector deflectorThirdClassForAvgure1 = new DeflectorThirdClass();
        yield return new object[]
        {
            new AvgureShip(deflectorThirdClassForAvgure1),
            new NavigateRouteResult.Success(2),
        };
        IDeflector deflectorSecondClassForMeredian1 = new DeflectorSecondClass();
        yield return new object[]
        {
            new MeredianShip(deflectorSecondClassForMeredian1),
            new NavigateRouteResult.Success(2),
        };
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest1))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult(ISpaceShip spaceShip, IRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55));

        // Act
        IRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest2))]
    public void NavigateRouteResult_ReturnNavigateNebulaeIncreasedDensitySpaceResult_WhenObstacleAntimatterFlares(ISpaceShip spaceShip, IRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeIncreasedDensitySpace(55, new ObstacleAntimatterFlares()));

        // Act
        IRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }

    [Theory]
    [MemberData(nameof(GetShipAndNavigateRouteResultTest3))]
    public void NavigateRouteResult_ReturnNavigateNebulaeNeutrinoParticlesResult_WhenCosmoWhale(ISpaceShip spaceShip, IRouteResult expectedRouteResult)
    {
        // Arrange
        var route = new Route(new NebulaeNeutrinoParticles(10, new CosmoWhale()));

        // Act
        IRouteResult result = route.RouteResult(spaceShip);

        // Assert
        Assert.Equal(expectedRouteResult, result);
    }
}