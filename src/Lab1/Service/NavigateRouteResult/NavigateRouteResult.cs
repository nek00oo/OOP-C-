using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.NavigateRouteResult;

public abstract record NavigateRouteResult
{
    private NavigateRouteResult() { }

    public static void ProcessingResults(NavigateRouteResult navigateRouteResult)
    {
        if (navigateRouteResult is Success success)
        {
            Console.WriteLine($"Successful overcoming of spaces. Spent fuel : {success.FuelQuantity}");
            return;
        }

        if (navigateRouteResult is CrewKilled)
        {
            Console.WriteLine("The crew was killed");
            return;
        }

        if (navigateRouteResult is ShipIsLost)
        {
            Console.WriteLine("The ship was lost");
            return;
        }

        if (navigateRouteResult is ShipIsDestroyed)
        {
            Console.WriteLine("The ship was destroyed");
        }
    }

    public sealed record Success(double FuelQuantity) : NavigateRouteResult; // Добавить количество потраченных денег

    public sealed record CrewKilled : NavigateRouteResult;

    public sealed record ShipIsLost : NavigateRouteResult;

    public sealed record ShipIsDestroyed : NavigateRouteResult;
}