using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service;

public interface IConfigurator
{
    IConfigurator AddWiFiAdapter(IWiFiAdapter wiFiAdapter);
    IComputer Build();
}