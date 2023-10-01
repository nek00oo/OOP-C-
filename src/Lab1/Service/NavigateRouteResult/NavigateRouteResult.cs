using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

public abstract record NavigateRouteResult
{
    private NavigateRouteResult() { }

    public static void ProcessingResults(NavigateRouteResult navigateRouteResult)
    {
        if (navigateRouteResult is Success success)
        {
            Console.WriteLine($"Successful overcoming of spaces. The {success.SpaceShip.GetType().Name} spaceship spent {Math.Round(success.FuelQuantityActivePlasma, 2)} active plasmas and {Math.Round(success.FuelQuantityGravitonMatter, 2)} graviton matters");
            return;
        }

        if (navigateRouteResult is CrewKilled crewKilled)
        {
            Console.WriteLine($"The crew of the spaceship {crewKilled.SpaceShip.GetType().Name} was killed");
            return;
        }

        if (navigateRouteResult is ShipIsLost shipIsLost)
        {
            Console.WriteLine($"The spaceship {shipIsLost.SpaceShip.GetType().Name} was lost");
            return;
        }

        if (navigateRouteResult is ShipIsDestroyed shipIsDestroyed)
        {
            Console.WriteLine($"The spaceship {shipIsDestroyed.SpaceShip.GetType().Name} was destroyed");
        }
    }

    public sealed record Success(SpaceShipBase SpaceShip, double FuelQuantityActivePlasma, double FuelQuantityGravitonMatter) : NavigateRouteResult; // Добавить количество потраченных денег

    public sealed record CrewKilled(SpaceShipBase SpaceShip) : NavigateRouteResult;

    public sealed record ShipIsLost(SpaceShipBase SpaceShip) : NavigateRouteResult;

    public sealed record ShipIsDestroyed(SpaceShipBase SpaceShip) : NavigateRouteResult;
}