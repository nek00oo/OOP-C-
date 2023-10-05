using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class DefinitionEffectiveShipTests
{
    public static IEnumerable<object[]> GetSpaceAndSpaceShips()
    {
        yield return new object[]
        {
            new OrdinarySpace(30),
            new PleasureShuttle(),
            new VaclasShip(),
        };
        yield return new object[]
        {
            new NebulaeIncreasedDensitySpace(70),
            new StellaShip(),
            new AvgureShip(),
        };
        yield return new object[]
        {
            new NebulaeNeutrinoParticles(50),
            new VaclasShip(),
            new PleasureShuttle(),
        };
        yield return new object[]
        {
            new NebulaeNeutrinoParticles(50),
            new VaclasShip(),
            new PleasureShuttle(),
        };
    }

    public static IEnumerable<object[]> GetSpaceListAndSpaceShipList()
    {
        var spaces = new List<SpaceBase>()
        {
            new OrdinarySpace(40, new ObstacleMeteorite()),
            new NebulaeNeutrinoParticles(20),
            new NebulaeIncreasedDensitySpace(75, new ObstacleAntimatterFlares()),
        };
        var spaceShips = new List<SpaceShipBase>()
        {
            new StellaShip(true),
            new AvgureShip(true),
            new VaclasShip(),
            new StellaShip(),
            new PleasureShuttle(),
        };
        yield return new object[]
        {
            spaces,
            spaceShips,
        };
    }

    [Theory]
    [MemberData(nameof(GetSpaceAndSpaceShips))]
    public void DefinitionEffectiveShip_ReturnMostEfficientShip(SpaceBase spaces, params SpaceShipBase[] spaceShips)
    {
        // Arrange
        IFuelExchange fuelExchange = new FuelExchange(10, 20);
        var route = new Route(spaces);
        var spaceShipsCollection = spaceShips.ToList();

        var definitionEffectiveShipService = new DefinitionEffectiveShip(spaceShipsCollection, route, fuelExchange);

        // Act
        SpaceShipBase? result = definitionEffectiveShipService.FindEffectiveShip();

        // Assert
        Assert.Equal(spaceShips[0], result);
    }

    [Theory]
    [MemberData(nameof(GetSpaceListAndSpaceShipList))]
    public void DefinitionEffectiveShip_ReturnMostEfficientShipTest2(IReadOnlyCollection<SpaceBase> space, IReadOnlyCollection<SpaceShipBase> spaceShips)
    {
        // Arrange
        IFuelExchange fuelExchange = new FuelExchange(10, 20);
        var route = new Route(space);

        var definitionEffectiveShipService = new DefinitionEffectiveShip(spaceShips, route, fuelExchange);

        // Act
        SpaceShipBase? result = definitionEffectiveShipService.FindEffectiveShip();

        // Assert
        Assert.Equal(spaceShips.First(), result);
    }
}