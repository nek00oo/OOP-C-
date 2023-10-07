using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Service.DefinitionEffectiveShip;
using Itmo.ObjectOrientedProgramming.Lab1.Service.FuelExchange;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class DefinitionEffectiveShipTests
{
    public static IEnumerable<object[]> GetSpaceAndSpaceShips()
    {
        IDeflector deflectorFirstClassForVaclas1 = new DeflectorFirstClass();
        yield return new object[]
        {
            new OrdinarySpace(20),
            new PleasureShuttle(),
            new VaclasShip(deflectorFirstClassForVaclas1),
        };
        IDeflector deflectorFirstClassForStella1 = new DeflectorFirstClass();
        IDeflector deflectorThirdClassForAvgure = new DeflectorThirdClass();
        yield return new object[]
        {
            new NebulaeIncreasedDensitySpace(70),
            new StellaShip(deflectorFirstClassForStella1),
            new AvgureShip(deflectorThirdClassForAvgure),
        };
        IDeflector deflectorFirstClassForVaclas2 = new DeflectorFirstClass();
        yield return new object[]
        {
            new NebulaeNeutrinoParticles(14),
            new VaclasShip(deflectorFirstClassForVaclas2),
            new PleasureShuttle(),
        };
    }

    public static IEnumerable<object[]> GetSpaceListAndSpaceShipList()
    {
        var spaces = new List<ISpace>()
        {
            new OrdinarySpace(40, new ObstacleMeteorite()),
            new NebulaeNeutrinoParticles(2),
            new NebulaeIncreasedDensitySpace(75, new ObstacleAntimatterFlares()),
        };
        IDeflector deflectorFirstClassForStella1 = new DeflectorFirstClass();
        deflectorFirstClassForStella1 = new PhotonDeflector(deflectorFirstClassForStella1);
        IDeflector deflectorThirdClassForAvgure1 = new DeflectorThirdClass();
        deflectorThirdClassForAvgure1 = new PhotonDeflector(deflectorThirdClassForAvgure1);
        IDeflector deflectorFirstClassForVaclas1 = new DeflectorFirstClass();
        IDeflector deflectorFirstClassForStella2 = new DeflectorFirstClass();
        var spaceShips = new List<ISpaceShip>()
        {
            new StellaShip(deflectorFirstClassForStella1),
            new AvgureShip(deflectorThirdClassForAvgure1),
            new VaclasShip(deflectorFirstClassForVaclas1),
            new StellaShip(deflectorFirstClassForStella2),
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
    public void DefinitionEffectiveShip_ReturnMostEfficientShip(ISpace space, params ISpaceShip[] spaceShips)
    {
        // Arrange
        IFuelExchange fuelExchange = new FuelExchange(10, 20);
        var route = new Route(space);
        var spaceShipsCollection = spaceShips.ToList();
        var definitionEffectiveShipService = new DefinitionEffectiveShip(spaceShipsCollection, route, fuelExchange);

        // Act
        ISpaceShip? result = definitionEffectiveShipService.FindEffectiveShip();

        // Assert
        Assert.Equal(spaceShips[0], result);
    }

    [Theory]
    [MemberData(nameof(GetSpaceListAndSpaceShipList))]
    public void DefinitionEffectiveShip_ReturnMostEfficientShipTest2(IReadOnlyCollection<ISpace> spaces, IReadOnlyCollection<ISpaceShip> spaceShips)
    {
        // Arrange
        IFuelExchange fuelExchange = new FuelExchange(10, 20);
        var route = new Route(spaces);
        var definitionEffectiveShipService = new DefinitionEffectiveShip(spaceShips, route, fuelExchange);

        // Act
        ISpaceShip? result = definitionEffectiveShipService.FindEffectiveShip();

        // Assert
        Assert.Equal(spaceShips.First(), result);
    }
}